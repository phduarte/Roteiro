using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Beneficios {

    internal class Beneficio : Entity, IBeneficio {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }

        public Beneficio() {

        }

        public Beneficio(Identity id) : base(id) {

        }

        public override string ToString() {
            return Nome;
        }
    }
}