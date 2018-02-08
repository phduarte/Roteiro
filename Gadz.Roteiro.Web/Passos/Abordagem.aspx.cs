using System;

namespace Gadz.Roteiro.Web.Passos {

    public partial class Abordagem : Passo {


        public Abordagem() {

        }

        protected void Page_Load(object sender, EventArgs e) {

            if (Interacao == null)
                Response.Redirect("~");

            if (!IsPostBack) {
                Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Abordagem");
                BtnVoltar.Visible = false;
                Preencher();
            }
        }
        //
        void Preencher() {

            //string _nome = App.CurrentUser.Nome;

            //if (_nome.IndexOf(' ') > 0)
            //    _nome = _nome.Substring(0, _nome.IndexOf(' '));

            if (DateTime.Now.Hour < 12)
                Saudacao.Text = "Bom dia!";
            else if (DateTime.Now.Hour < 18)
                Saudacao.Text = "Boa Tarde!";
            else
                Saudacao.Text = "Boa Noite!";

            Texto.Text = Interacao?.Abordagem;
        }
        //
        protected override bool Salvar() {
            Interacao.IniciarConversar();
            return base.Salvar();
        }
    }
}