using Gadz.Roteiro.Access;
using System;
using System.Web.Security;

namespace Gadz.Roteiro.Web.Acesso {

    public partial class Login : Pagina {

        AccessServices _services = AccessServices.Instance;

        protected void Page_Load(object sender, EventArgs e) {
        }
        //
        protected void Entrar(object sender, EventArgs e) {
            if(_services.ValidarUsuario(txtUsuario.Value, txtSenha.Value)) {
                FormsAuthentication.RedirectFromLoginPage(txtUsuario.Value, false);
            } else {
                Msgbox.Show("Usuário ou senha inválidos.");
            }
        }
    }
}