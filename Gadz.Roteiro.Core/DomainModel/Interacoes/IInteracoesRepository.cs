using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IInteracoesRepository : IRepositoryReadOnly<IInteracao> {
        IInteracao GetPending(Identity id, Identity idCampanha);
        IInteracao Create(Identity id, Identity idCampanha);
        void Save(IInteracao interacao);
    }
}
