using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Planos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class BeneficiosRepository : RepositoryBase, IBeneficiosRepository {

        public IEnumerable<IBeneficio> GetAllOf(IPlano plano) {
            return GetAllOf<IBeneficio>("SELECT * FROM Beneficios WHERE PlanoId = @Id", plano);
        }

        protected override T Map<T>(SqlDataReader rec) {
            return (T)(object)new Beneficio(rec["Id"].ToString()) {
                Descricao = rec["Descricao"].ToString(),
                Icone = rec["Icone"].ToString(),
                Nome = rec["Nome"].ToString()
            };
        }
    }
}
