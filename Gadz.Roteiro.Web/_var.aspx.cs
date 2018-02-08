using System;
using System.Web.UI;

namespace Gadz.Roteiro.Web {

    /// <summary>
    /// Contem os valores que atualmente estão sendo usados pelas variáveis de aplicação sessão,
    /// cookies e Server variables
    /// </summary>
    public partial class _var : Page {

        /// <summary>
        /// Redefine a visualização padrão da página atual.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e) {

            if(!Page.IsPostBack) {

                string x = "";

                if(Request.Form.Count > 0)
                    x = Request.Form["crack"].ToString().ToUpper();

                if(x.Equals("BREAK")) {

                    Session.RemoveAll();
                    Session.Abandon();

                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now;

                    //Response.Redirect("_var.aspx");
                }
            }
        }
    }
}