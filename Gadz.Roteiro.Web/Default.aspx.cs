using System;

namespace Gadz.Roteiro.Web {

    public partial class Default : Pagina {

        protected void Page_Load(object sender, EventArgs e) {
            Response.Redirect("~/Campanhas/Default.aspx");
        }
    }
}