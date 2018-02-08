using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Validacoes {
    internal class Validacao : Entity, IValidacao {

        public string Texto { get; set; }
        public ICampanha Campanha { get; set; }

        public Validacao() {

        }

        public Validacao(Identity id) : base(id) {

        }

        public override string ToString() {
            return Texto;
        }
    }
}