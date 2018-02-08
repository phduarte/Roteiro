using System;

namespace Gadz.Roteiro.Web.Vendedores {

    public partial class Default : Pagina {

        protected void Page_Load(object sender, EventArgs e) {
            Response.Redirect("~/Pesquisar.aspx");
        }
    }
}