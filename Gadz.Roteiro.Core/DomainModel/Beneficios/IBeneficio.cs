using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Planos;

namespace Gadz.Roteiro.Core.DomainModel.Beneficios {
    public interface IBeneficio : IEntity {
        string Descricao { get; }
        string Icone { get; }
        string Nome { get; }
        IPlano Plano { get; }
    }
}