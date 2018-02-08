using Gadz.Roteiro.Core;
using System;
using System.Web.Security;

namespace Gadz.Roteiro.Web.Acesso {

    public partial class Login : Pagina {

        RoteiroServices _services = RoteiroServices.Instance;

        protected void Page_Load(object sender, EventArgs e) {
        }
        //
        protected void Entrar(object sender, EventArgs e) {
            if(_services.Validate(txtUsuario.Value, txtSenha.Value)) {
                App.SerCurrentUser(_services.PegarVendedorPorUsername(txtUsuario.Value));
                FormsAuthentication.RedirectFromLoginPage(txtUsuario.Value, false);
            } else {
                Msgbox.Show("Usuário ou senha inválidos.");
            }
        }
    }
}