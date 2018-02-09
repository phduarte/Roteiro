using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class PlanosRepository : RepositoryBase, IPlanosRepository {

        readonly IBeneficiosRepository _beneficios;

        public PlanosRepository(IBeneficiosRepository beneficios) {
            _beneficios = beneficios;
        }

        public IPlano Get(Identity id) {
            return Get<IPlano>("SELECT * FROM Planos Where Id = @Id", id);
        }

        public IEnumerable<IPlano> GetAllOf(ICampanha campanha) {
            return GetAllOf<IPlano>("SELECT * FROM Planos a WHERE CampanhaId = @Id", campanha);
        }

        public new IEnumerable<IPlano> GetAllOf(IInteracao entity) {
            return GetAllOf<IPlano>("SELECT a.* FROM Planos a INNER JOIN InteracoesPlanos b on a.Id = b.PlanoId where b.InteracaoId = @Id", entity);
        }

        protected override T Map<T>(SqlDataReader rec) {

            var plano = new Plano(rec["Id"].ToString()) {
                Descricao = rec["Descricao"].ToString(),
                Nome = rec["Nome"].ToString(),
                Preco = decimal.Parse(rec["Preco"].ToString()),
                Tipo = (PlanoTipo)int.Parse(rec["Tipo"].ToString())
            };

            plano.Beneficios = _beneficios.GetAllOf(plano).ToList();

            return (T)(object)plano;
        }
    }
}
