using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class CampanhasRepository : RepositoryBase, ICampanhasRepository {

        #region fields

        readonly IPremissasRepository _premissas;
        readonly IObjecoesRepository _objecoes;
        readonly IPlanosRepository _planos;
        readonly IValidacoesRepository _validacoes;

        #endregion

        public CampanhasRepository() {
            _premissas = new PremissasRepository();
            _objecoes = new ObjecoesRepository();
            _planos = new PlanosRepository(new BeneficiosRepository());
            _validacoes = new ValidacoesRepository();
        }

        public ICampanha Get(Identity id) {
            return Get<ICampanha>("SELECT * FROM Campanhas WHERE Id = @Id", id);
        }

        public IEnumerable<ICampanha> GetAllOf(IVendedor vendedor) {
            var sql = @"SELECT a.*
                            FROM Campanhas a
                            INNER JOIN VendedoresCampanhas b ON a.Id = b.CampanhaId
                            WHERE VendedorId = @Id";
            return GetAllOf<ICampanha>(sql, vendedor);
        }

        protected override T Map<T>(SqlDataReader rec) {

            var campanha = new Campanha(rec["Id"].ToString()) {
                Abordagem = rec["Abordagem"].ToString(),
                Descricao = rec["Descricao"].ToString(),
                Icone = rec["Icone"].ToString(),
                Nome = rec["Nome"].ToString()
            };

            campanha.Objecoes = _objecoes.GetAllOf(campanha).ToList();
            campanha.Planos = _planos.GetAllOf(campanha).ToList();
            campanha.Premissas = _premissas.GetAllOf(campanha).ToList();
            campanha.Validacoes = _validacoes.GetAllOf(campanha).ToList();

            return (T)(object)campanha;
        }
    }
}
