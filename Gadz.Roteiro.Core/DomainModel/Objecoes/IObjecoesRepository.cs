using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Objecoes {
    public interface IObjecoesRepository : IRepositoryRelationFor<IObjecao,ICampanha>, IRepositoryReadOnly<IObjecao> {
    }
}
