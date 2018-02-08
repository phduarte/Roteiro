using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Planos {
    public interface IPlanosRepository : IRepositoryRelationFor<IPlano,ICampanha>, IRepositoryReadOnly<IPlano> {
    }
}
