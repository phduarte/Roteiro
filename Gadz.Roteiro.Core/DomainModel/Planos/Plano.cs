using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Planos {

    internal class Plano : Entity, IPlano {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool ZonaConcorrencia { get; set; }
        public string Localidade { get; set; }
        public decimal GastoMensal { get; set; }
        public decimal GastoMensalOi { get; set; }
        public decimal GastoMensalOutras { get; set; }

        public PlanoTipo Tipo { get; set; }
        public ICampanha Campanha { get; set; }
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