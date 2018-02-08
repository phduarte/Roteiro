using System;

namespace Gadz.Roteiro.Web.Controls {
    public partial class Header : System.Web.UI.UserControl {

        public string AppName => App.Nome;

        protected void Page_Load(object sender, EventArgs e) {
            imgLogout.Visible = Context.User.Identity.IsAuthenticated;
        }
    }
}