using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Objecoes {
    public interface IObjecao : IEntity {
        string Motivo { get; }
        string ContraArgumento { get; }
    }
}