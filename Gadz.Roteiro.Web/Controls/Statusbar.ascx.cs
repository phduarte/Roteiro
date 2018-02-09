using System;

namespace Gadz.Roteiro.Web.Controls {
    public partial class Statusbar : System.Web.UI.UserControl {

        protected bool logado => Context.User.Identity.IsAuthenticated;

        protected void Page_Load(object sender, EventArgs e) {

            if (App.CurrentUser == null)
                return;

            lbRota.Text = new Pagina().Rota.Pegar();
            lbPerfil.Text = string.Format($"{App.CurrentUser.Username} | {App.CurrentUser.Nome} | {App.CurrentUser.Perfil}");
        }
    }
}