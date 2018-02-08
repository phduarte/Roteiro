using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Planos;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class BeneficiosRepository : RepositoryBase, IBeneficiosRepository {

        IPlano _plano;

        public IEnumerable<IBeneficio> GetAllOf(IPlano plano) {
            _plano = plano;
            return GetAllOf<IBeneficio>("SELECT * FROM Beneficios WHERE PlanoId = @Id", _plano);
        }

        protected override T Map<T>(dynamic rec) {
            return (T)(object)new Beneficio(rec["Id"].ToString()) {
                Descricao = rec["Descricao"].ToString(),
                Icone = rec["Icone"].ToString(),
                Nome = rec["Nome"].ToString(),
                Plano = _plano
            };
        }
    }
}
