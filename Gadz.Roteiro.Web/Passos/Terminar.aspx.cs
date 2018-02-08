using System;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Terminar : Passo {

        //
        protected void Page_Load(object sender, EventArgs e) {
            if (Salvar()) {
                if (Request.QueryString != null && Request.QueryString["id"] != null) {
                    //Response.Redirect(string.Format("~/Passos/Iniciar.aspx?idCampanha={0}", PegarCampanhaDaInteracao(Request.QueryString["id"])));
                    Response.Redirect($"~/Passos/Iniciar.aspx?c={Interacao.Campanha.Id}");
                } else {
                    Response.Redirect("~/Default.aspx");
                }
            } else {
                Msgbox.Show("Falha ao tentar finalizar o registro.");
            }
        }
        //
        protected override bool Salvar() {
            Interacao.Terminar();
            return base.Salvar();
        }
    }
}