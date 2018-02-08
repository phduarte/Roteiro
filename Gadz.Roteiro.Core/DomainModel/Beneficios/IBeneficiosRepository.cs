using Gadz.Roteiro.Core.DomainModel.Planos;

namespace Gadz.Roteiro.Core.DomainModel.Beneficios {
    public interface IBeneficiosRepository : IRepositoryRelationFor<IBeneficio,IPlano> {
    }
}
