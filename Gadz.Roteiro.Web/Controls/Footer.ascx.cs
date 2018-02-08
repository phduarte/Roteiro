using System;

namespace Gadz.Roteiro.Web.Controls {
    public partial class Footer : System.Web.UI.UserControl {

        public string Versao => App.Versao;
        public string Autor => App.Autor;
        public string Powered => App.Powered;
        public string Email => App.EmailSuporte;

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}