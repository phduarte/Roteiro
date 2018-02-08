using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Clientes {
    internal class ClienteIndefinido : Entity, ICliente {

        public Name Nome { get; }
        public string Email { get; }
        public string Endereco { get; }
        public string Telefone { get; }
        public Documento Documento { get; }

        public ClienteIndefinido() {
            Nome = "NÃO DEFINIDO";
            Email = "contato@gadz.com.br";
            Endereco = "undefined";
            Telefone = "";
            Documento = new Documento("CNPJ", "1234560001/9");
        }

        public override string ToString() {
            return Nome;
        }
    }
}
