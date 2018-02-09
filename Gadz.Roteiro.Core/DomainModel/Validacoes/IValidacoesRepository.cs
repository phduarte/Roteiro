using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Core.DomainModel.Validacoes {
    public interface IValidacoesRepository : IRepositoryReadOnly<IValidacao>,
        IRepositoryRelationFor<IValidacao, ICampanha>,
        IRepositoryRelationFor<IValidacao, IInteracao> {
    }
}
