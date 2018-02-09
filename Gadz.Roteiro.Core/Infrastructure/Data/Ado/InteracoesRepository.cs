using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class InteracoesRepository : RepositoryBase, IInteracoesRepository {

        #region fields

        ICampanhasRepository _campanhas;
        IVendedoresRepository _vendedores;
        IObjecoesRepository _objecoes;
        IPlanosRepository _planos;
        IPremissasRepository _premissas;
        IValidacoesRepository _validacoes;

        #endregion

        public InteracoesRepository(ICampanhasRepository campanhas) {
            _campanhas = campanhas;
            _vendedores = new VendedoresRepository(_campanhas);
            _objecoes = new ObjecoesRepository();
            _planos = new PlanosRepository(new BeneficiosRepository());
            _premissas = new PremissasRepository();
            _validacoes = new ValidacoesRepository();
        }

        public IInteracao Create(Identity idVendedor, Identity idCampanha) {

            var vendedor = _vendedores.Get(idVendedor);
            var campanha = _campanhas.Get(idCampanha);
            var interacao = new Interacao { Campanha = campanha, Vendedor = vendedor };

            Save(interacao);

            return interacao;
        }

        public IInteracao Get(Identity id) {
            return Get<IInteracao>("SELECT * FROM Interacoes WHERE Id = @Id", id);
        }

        public IInteracao GetPending(Identity idVendedor, Identity idCampanha) {

            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.CommandText = "SELECT * FROM Interacoes WHERE VendedorId = @VendedorId AND CampanhaId = @CampanhaId and Concluida = 0";
                    cmd.Parameters.AddWithValue("@VendedorId", idVendedor.ToString());
                    cmd.Parameters.AddWithValue("@CampanhaId", idCampanha.ToString());

                    using (var rec = cmd.ExecuteReader()) {

                        if (rec.Read()) {
                            return Map<IInteracao>(rec);
                        }
                    }
                }
            }

            return null;
        }

        public void Save(IInteracao interacao) {
            if (interacao.Exists) {
                Atualizar(interacao);
            } else {
                Adicionar(interacao);
            }
        }

        void Adicionar(IInteracao interacao) {
            string sql = @"INSERT Interacoes(Id,VendedorId,CampanhaId,Inicio,Termino,Status,Concluida) 
                            VALUES(@Id,@VendedorId,@CampanhaId,@Inicio,@Termino,@Status,@Concluida)";

            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@VendedorId", interacao.Vendedor.Id.ToString());
                    cmd.Parameters.AddWithValue("@CampanhaId", interacao.Campanha.Id.ToString());
                    cmd.Parameters.AddWithValue("@Inicio", interacao.Inicio);
                    cmd.Parameters.AddWithValue("@Termino", interacao.Termino??new DateTime(1900,1,1));
                    cmd.Parameters.AddWithValue("@Status", interacao.Status.Nome);
                    cmd.Parameters.AddWithValue("@Concluida", interacao.Status.Concluida);

                    cmd.CommandText = sql;

                    cmd.ExecuteNonQuery();
                }

                AtualizarTabelasVinculadas(interacao, conn);
            }
        }

        void Atualizar(IInteracao interacao) {
            string sql = @"UPDATE Interacoes 
                           SET  VendedorId = @VendedorId,
                                CampanhaId = @CampanhaId,
                                Inicio = @Inicio, 
                                Termino = @Termino,
                                Status = @Status,
                                Concluida = @Concluida
                           WHERE Id = @Id";

            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@VendedorId", interacao.Vendedor.Id.ToString());
                    cmd.Parameters.AddWithValue("@CampanhaId", interacao.Campanha.Id.ToString());
                    cmd.Parameters.AddWithValue("@Inicio", interacao.Inicio);
                    cmd.Parameters.AddWithValue("@Termino", interacao.Termino);
                    cmd.Parameters.AddWithValue("@Status", interacao.Status.Nome);
                    cmd.Parameters.AddWithValue("@Concluida", interacao.Status.Concluida);

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }

                AtualizarTabelasVinculadas(interacao, conn);
            }
        }

        private static void AtualizarTabelasVinculadas(IInteracao interacao, System.Data.SqlClient.SqlConnection conn) {
            AtualizarObjecoes(interacao, conn);
            AtualizarPremissas(interacao, conn);
            AtualizarPlanos(interacao, conn);
            AtualizarValidacoes(interacao, conn);
        }

        private static void AtualizarValidacoes(IInteracao interacao, SqlConnection conn) {
            using (var cmd = conn.CreateCommand()) {
                cmd.CommandText = "DELETE FROM InteracoesValidacoes WHERE InteracaoId = @Id";
                cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                cmd.ExecuteNonQuery();
            }

            foreach (var v in interacao.Validacoes) {
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = @"INSERT INTO InteracoesValidacoes(InteracaoId,ValidacaoId) VALUES(@InteracaoId,@ValidacaoId)";
                    cmd.Parameters.AddWithValue("@InteracaoId", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@ValidacaoId", v.Id.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void AtualizarPlanos(IInteracao interacao, SqlConnection conn) {
            using (var cmd = conn.CreateCommand()) {
                cmd.CommandText = "DELETE FROM InteracoesPlanos WHERE InteracaoId = @Id";
                cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                cmd.ExecuteNonQuery();
            }

            foreach (var p in interacao.Planos) {
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = @"INSERT INTO InteracoesPlanos(InteracaoId,PlanoId) VALUES(@InteracaoId,@PlanoId)";
                    cmd.Parameters.AddWithValue("@InteracaoId", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@PlanoId", p.Id.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void AtualizarPremissas(IInteracao interacao, SqlConnection conn) {
            using (var cmd = conn.CreateCommand()) {
                cmd.CommandText = "DELETE FROM InteracoesPremissas WHERE InteracaoId = @Id";
                cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                cmd.ExecuteNonQuery();
            }

            foreach (var p in interacao.Premissas) {
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = @"INSERT INTO InteracoesPremissas(InteracaoId,PremissaId,Resposta) VALUES(@InteracaoId,@PremissaId,@Resposta)";
                    cmd.Parameters.AddWithValue("@InteracaoId", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@PremissaId", p.Id.ToString());
                    cmd.Parameters.AddWithValue("@Resposta", p.Resposta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void AtualizarObjecoes(IInteracao interacao, SqlConnection conn) {
            using (var cmd = conn.CreateCommand()) {
                cmd.CommandText = "DELETE FROM InteracoesObjecoes WHERE InteracaoId = @Id";
                cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                cmd.ExecuteNonQuery();
            }

            foreach (var o in interacao.Objecoes) {
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = @"INSERT INTO InteracoesObjecoes(InteracaoId,ObjecaoId) VALUES(@InteracaoId,@ObjecaoId)";
                    cmd.Parameters.AddWithValue("@InteracaoId", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@ObjecaoId", o.Id.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected override T Map<T>(SqlDataReader rec) {

            var interacao = new Interacao(rec["Id"].ToString()) {
                Status = StatusInteracao.Parse(rec["Status"].ToString()),
                Inicio = DateTime.Parse(rec["Inicio"].ToString())
            };

            if (DateTime.TryParse(rec["Termino"].ToString(), out DateTime termino)) {
                interacao.Termino = termino;
            }

            interacao.Campanha = _campanhas.Get(Identity.Create(rec["CampanhaId"].ToString()));
            interacao.Vendedor = _vendedores.Get(Identity.Create(rec["VendedorId"].ToString()));
            interacao.Planos = _planos.GetAllOf(interacao).ToList();
            interacao.Premissas = _premissas.GetAllOf(interacao).ToList();
            interacao.Objecoes = _objecoes.GetAllOf(interacao).ToList();
            interacao.Validacoes = _validacoes.GetAllOf(interacao).ToList();

            return (T)(object)interacao;
        }
    }
}
