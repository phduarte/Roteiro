using System;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Terminar : Passo {

        //
        protected void Page_Load(object sender, EventArgs e) {

            if (interacao == null)
                Response.Redirect("~");

            BtnAvancar.Text = "Terminar";
            lbProtocolo.Text = interacao.Id;

            if(interacao.Status.Vendida) {
                txtTexto.Text = "Obrigado pela sua preferência e parabéns pela sua escolha.";
            } else {
                txtTexto.Text = "Obrigado pela sua atenção. Esperamos que haja outra oportunidade futuramente.";
            }
        }

        protected override void Voltar(object sender, EventArgs e) {

            if (interacao.Status.Vendida) {
                Response.Redirect($"Aceite.aspx?id={interacao.Id}");
            } else {
                Response.Redirect($"Rebate.aspx?id={interacao.Id}");
            }
        }

        protected override void Avancar(object sender, EventArgs e) {

            if (Salvar()) {
                if (Request.QueryString != null && Request.QueryString["id"] != null) {
                    Response.Redirect($"Iniciar.aspx?c={interacao.Campanha.Id}");
                } else {
                    Response.Redirect("~/Default.aspx");
                }
            } else {
                Msgbox.Show("Falha ao tentar finalizar o registro.");
            }
        }
        //
        protected override bool Salvar() {
            interacao.Terminar();
            return base.Salvar();
        }
    }
}