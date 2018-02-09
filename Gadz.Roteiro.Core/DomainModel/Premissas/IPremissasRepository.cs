using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Core.DomainModel.Premissas {
    public interface IPremissasRepository : IRepositoryReadOnly<IPremissa>,
        IRepositoryRelationFor<IPremissa, ICampanha>,
        IRepositoryRelationFor<IPremissa, IInteracao> {
    }
}
