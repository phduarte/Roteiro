using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Validacoes {
    public interface IValidacao : IEntity {
        string Texto { get; set; }
    }
}