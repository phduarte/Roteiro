using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Core.DomainModel.Objecoes {
    public interface IObjecoesRepository : IRepositoryReadOnly<IObjecao>,
        IRepositoryRelationFor<IObjecao, ICampanha>,
        IRepositoryRelationFor<IObjecao, IInteracao> {
    }
}
