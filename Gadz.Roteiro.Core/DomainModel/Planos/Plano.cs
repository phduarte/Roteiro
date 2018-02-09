using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Planos {

    internal class Plano : Entity, IPlano {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public PlanoTipo Tipo { get; set; }
        public IList<IBeneficio> Beneficios { get; set; } = new List<IBeneficio>();

        public Plano() {
        }

        public Plano(Identity id) : base(id) {
        }

        public override string ToString() {
            return Nome;
        }
    }
}