using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Clientes {
    internal class Cliente : Entity, ICliente {

        public Name Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public Documento Documento { get; }
        
        public override string ToString() {
            return Nome;
        }
    }
}
