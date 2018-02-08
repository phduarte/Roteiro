using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Objecoes {
    public interface IObjecao : IEntity {
        string Motivo { get; }
        string ContraArgumento { get; }
        ICampanha Campanha { get; }
    }
}