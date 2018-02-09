using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Validacoes {
    internal class Validacao : Entity, IValidacao {

        public string Texto { get; set; }

        public Validacao() {

        }

        public Validacao(Identity id) : base(id) {

        }

        public override string ToString() {
            return Texto;
        }
    }
}