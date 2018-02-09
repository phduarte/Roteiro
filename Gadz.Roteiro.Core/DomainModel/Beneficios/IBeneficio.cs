using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Beneficios {
    public interface IBeneficio : IEntity {
        string Descricao { get; }
        string Icone { get; }
        string Nome { get; }
    }
}