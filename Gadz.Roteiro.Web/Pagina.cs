using Sirmione.Web.Forms;

namespace Gadz.Roteiro.Web {

    public class Pagina : PageBase {

        public Rota Rota { get; }

        public Pagina() {
            Rota = new Rota();
            Page.PreInit += (sender,e)=> { AlterarTema("Oi"); };
        }
        //
        protected void AlterarTema(string tema) {
            //if (sessao != null && !string.IsNullOrEmpty(sessao.Operacao))
            //    Page.Theme = sessao.Operacao;
            Page.Theme = tema;
        }


        protected string PegarParametroQuerystring(string parametro) {

            if(Request.QueryString != null && Request.QueryString[parametro] != null) {
                return Request.QueryString[parametro];
            }
            return string.Empty;
        }

        public bool IsInRole(string perfil) {
            return App.CurrentUser.Perfil.Equals(perfil);
        }
    }
}