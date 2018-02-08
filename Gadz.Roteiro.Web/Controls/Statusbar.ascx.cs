using System;

namespace Gadz.Roteiro.Web.Controls {
    public partial class Statusbar : System.Web.UI.UserControl {

        protected bool logado => Context.User.Identity.IsAuthenticated;

        protected void Page_Load(object sender, EventArgs e) {
            lbRota.Text = new Pagina().Rota.Pegar();

            //App.CurrentUser.Nome
            lbPerfil.Text = string.Format($"{App.CurrentUser.Username} | {App.CurrentUser.Nome} | {App.CurrentUser.Perfil}");
        }
    }
}