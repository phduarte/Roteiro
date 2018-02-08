using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Planos;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class PlanosRepository : RepositoryBase, IPlanosRepository {

        ICampanha _campanha;
        readonly IBeneficiosRepository _beneficios;

        public PlanosRepository() {
            _beneficios = new BeneficiosRepository();
        }

        public IPlano Get(Identity id) {
            return Get<IPlano>("SELECT * FROM Planos Where Id = @Id", id);
        }

        public IEnumerable<IPlano> GetAllOf(ICampanha campanha) {
            _campanha = campanha;
            return GetAllOf<IPlano>("SELECT * FROM Planos a WHERE CampanhaId = @Id", _campanha);
        }

        protected override T Map<T>(dynamic rec) {

            var plano = new Plano(rec["Id"].ToString()) {
                Campanha = _campanha,
                Descricao = rec["Descricao"].ToString(),
                Localidade = rec["Localidade"].ToString(),
                Nome = rec["Nome"].ToString(),
                Preco = decimal.Parse(rec["Preco"].ToString()),
                Tipo = (PlanoTipo)int.Parse(rec["Tipo"].ToString()),
                ZonaConcorrencia = rec["ZonaConcorrencia"].ToString().ToLower().Equals("true")
            };

            plano.Beneficios = _beneficios.GetAllOf(plano).ToList();

            return (T)(object)plano;
        }
    }
}
