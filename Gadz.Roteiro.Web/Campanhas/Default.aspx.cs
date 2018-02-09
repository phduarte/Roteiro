using System;
using System.Collections.Generic;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core;

namespace Gadz.Roteiro.Web.Campanhas {

    public partial class Default : Pagina {

        readonly RoteiroServices _roteiroServices;
        protected IList<ICampanha> campanhas = new List<ICampanha>();

        public Default() {
            _roteiroServices = RoteiroServices.Instance;
        }

        protected void Page_Load(object sender, EventArgs e) {

            if (!User.Identity.IsAuthenticated) {
                return;
            }

            Rota.Definir("<a href='../Default.aspx'>Início</a> > Campanhas");

            var vendedor = _roteiroServices.PegarVendedorPorUsername(User.Identity.Name);
            campanhas = vendedor.Campanhas;
        }
    }
}