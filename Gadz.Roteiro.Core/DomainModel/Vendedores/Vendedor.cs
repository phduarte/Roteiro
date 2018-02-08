using System.Collections.Generic;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Vendedores {
    internal class Vendedor : Usuario, IVendedor {

        public IList<ICampanha> Campanhas { get; set; } = new List<ICampanha>();

        public Vendedor() {
        }

        public Vendedor(Identity id) : base(id) {
        }

    }
}
