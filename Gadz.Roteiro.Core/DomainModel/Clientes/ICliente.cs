using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Clientes {
    public interface ICliente : IEntity {
        Name Nome { get; }
        string Email { get; }
        string Endereco { get; }
        string Telefone { get; }
        Documento Documento { get; }
    }
}
