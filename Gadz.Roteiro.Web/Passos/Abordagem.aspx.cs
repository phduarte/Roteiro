using System;

namespace Gadz.Roteiro.Web.Passos {

    public partial class Abordagem : Passo {

        protected void Page_Load(object sender, EventArgs e) {

            if (interacao == null)
                Response.Redirect("~");

            if (!IsPostBack) {
                Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Abordagem");
                BtnVoltar.Visible = false;
                Preencher();
            }
        }
        //
        void Preencher() {

            if (DateTime.Now.Hour < 12)
                Saudacao.Text = "Bom dia!";
            else if (DateTime.Now.Hour < 18)
                Saudacao.Text = "Boa Tarde!";
            else
                Saudacao.Text = "Boa Noite!";

            Texto.Text = interacao?.Abordagem;
        }
        //
        protected override bool Salvar() {
            interacao.IniciarConversar();
            return base.Salvar();
        }
    }
}