using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class InteracoesRepository : RepositoryBase, IInteracoesRepository {

        #region fields

        ICampanhasRepository _campanhas;
        IVendedoresRepository _vendedores;
        IObjecoesRepository _objecoes;
        IPlanosRepository _planos;

        #endregion

        public InteracoesRepository(ICampanhasRepository campanhas) {
            _campanhas = campanhas;
            _vendedores = new VendedoresRepository(_campanhas);
            _objecoes = new ObjecoesRepository(_campanhas);
            _planos = new PlanosRepository();
        }

        public IInteracao Create(Identity idVendedor, Identity idCampanha) {

            var vendedor = _vendedores.Get(idVendedor);
            var campanha = _campanhas.Get(idCampanha);

            return new Interacao { Campanha = campanha, Vendedor = vendedor };
        }

        public IInteracao Get(Identity id) {
            return Get<IInteracao>("SELECT * FROM Interacoes WHERE Id = @Id", id);
        }

        public IInteracao GetPending(Identity id, Identity idCampanha) {

            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.CommandText = "SELECT * FROM Interacoes WHERE VendedorId = @VendedorId AND CampanhaId = @CampanhaId";
                    cmd.Parameters.AddWithValue("@VendedorId", id.ToString());
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
            string sql = @"INSERT Interacoes(Id,VendedorId,CampanhaId,ObjecaoId,PlanoEscolhidoId,Inicio,Termino,Status) 
                            VALUES(@Id,@VendedorId,@CampanhaId,@ObjecaoId,@PlanoEscolhidoId,@Inicio,@Termino,@Status)";

            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@VendedorId", interacao.Vendedor.Id.ToString());
                    cmd.Parameters.AddWithValue("@CampanhaId", interacao.Campanha.Id.ToString());

                    if (interacao.Objecao == null) {
                        sql = sql.Replace(",ObjecaoId", "").Replace(",@ObjecaoId", "");
                    } else {
                        cmd.Parameters.AddWithValue("@ObjecaoId", interacao.Objecao?.Id.ToString());
                    }

                    if (interacao.PlanoEscolhido == null) {
                        sql = sql.Replace(",PlanoEscolhidoId", string.Empty).Replace(",@PlanoEscolhidoId", string.Empty);
                    } else {
                        cmd.Parameters.AddWithValue("@PlanoEscolhidoId", interacao.PlanoEscolhido?.Id.ToString());
                    }

                    cmd.Parameters.AddWithValue("@Inicio", interacao.Inicio);
                    cmd.Parameters.AddWithValue("@Termino", interacao.Termino);
                    cmd.Parameters.AddWithValue("@Status", interacao.Status.Nome);

                    cmd.CommandText = sql;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        void Atualizar(IInteracao interacao) {
            string sql = @"UPDATE Interacoes 
                           SET  VendedorId = @VendedorId,
                                CampanhaId = @CampanhaId,
                                ObjecaoId = @ObjecaoId,
                                PlanoEscolhidoId = @PlanoEscolhidoId,
                                Inicio = @Inicio, 
                                Termino = @Termino,
                                Status = @Status
                           WHERE Id = @Id";

            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.Parameters.AddWithValue("@Id", interacao.Id.ToString());
                    cmd.Parameters.AddWithValue("@VendedorId", interacao.Vendedor.Id.ToString());
                    cmd.Parameters.AddWithValue("@CampanhaId", interacao.Campanha.Id.ToString());

                    if (interacao.Objecao == null) {
                        sql = sql.Replace("ObjecaoId = @ObjecaoId,", "");
                    } else {
                        cmd.Parameters.AddWithValue("@ObjecaoId", interacao.Objecao?.Id.ToString());
                    }

                    if (interacao.PlanoEscolhido == null) {
                        sql = sql.Replace("PlanoEscolhidoId = @PlanoEscolhidoId,", string.Empty);
                    } else {
                        cmd.Parameters.AddWithValue("@PlanoEscolhidoId", interacao.PlanoEscolhido?.Id.ToString());
                    }

                    cmd.Parameters.AddWithValue("@Inicio", interacao.Inicio);
                    cmd.Parameters.AddWithValue("@Termino", interacao.Termino);
                    cmd.Parameters.AddWithValue("@Status", interacao.Status.Nome);

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected override T Map<T>(dynamic rec) {

            var interacao = new Interacao(rec["Id"].ToString()) {
                Status = StatusInteracao.Parse(rec["Status"].ToString()),
                Inicio = DateTime.Parse(rec["Inicio"].ToString()),
            };

            if (DateTime.TryParse(rec["Termino"].ToString(), out DateTime termino)) {
                interacao.Termino = termino;
            }

            interacao.Campanha = _campanhas.Get(new Identity(rec["CampanhaId"].ToString()));
            interacao.Vendedor = _vendedores.Get(new Identity(rec["VendedorId"].ToString()));

            if (!string.IsNullOrWhiteSpace(rec["PlanoEscolhidoId"].ToString())) {
                interacao.PlanoEscolhido = _planos.Get(new Identity(rec["PlanoEscolhidoId"].ToString()));
            }

            if (!string.IsNullOrWhiteSpace(rec["ObjecaoId"].ToString())) {
                interacao.Objecao = _objecoes.Get(new Identity(rec["ObjecaoId"].ToString()));
            }
            
            return (T)(object)interacao;
        }
    }
}
