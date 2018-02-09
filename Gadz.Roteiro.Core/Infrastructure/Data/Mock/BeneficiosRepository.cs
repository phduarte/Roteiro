using System.Collections.Generic;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Planos;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {

    internal class BeneficiosRepository : IBeneficiosRepository {


        public IEnumerable<IBeneficio> Find(Identity idPlano) {
            return new List<IBeneficio>();
        }

        public IEnumerable<IBeneficio> GetAllOf(IPlano plano) {
            return Find(plano.Id);
        }
    }
}
