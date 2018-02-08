using System;
using System.Web.Security;

namespace Gadz.Roteiro.Web.Acesso {

    public partial class Logout : Pagina {

        protected void Page_Load(object sender, EventArgs e) {
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now;
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
    }
}