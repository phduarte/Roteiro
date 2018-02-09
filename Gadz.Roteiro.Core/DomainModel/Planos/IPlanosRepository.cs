using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Core.DomainModel.Planos {
    public interface IPlanosRepository : IRepositoryReadOnly<IPlano>,
        IRepositoryRelationFor<IPlano, ICampanha>,
        IRepositoryRelationFor<IPlano, IInteracao> {
    }
}
