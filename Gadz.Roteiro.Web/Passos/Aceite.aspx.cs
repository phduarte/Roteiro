using System;
using System.Web.UI.WebControls;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Aceite : Passo {

        protected void Page_Load(object sender, EventArgs e) {

            if (interacao == null) {
                Response.Redirect("~");
            }

            if (!IsPostBack) {
                Rota.Definir("<a href='../Default.aspx'>Início</a> > " + CampanhaAtual + " > Venda");
                BtnAvancar.Text = "Concluir";

                Preencher();
            }
        }
        //
        void Preencher() {
            Validacoes.DataTextField = "Texto";
            Validacoes.DataValueField = "Id";
            Validacoes.DataSource = interacao.Campanha.Validacoes;
            Validacoes.DataBind();
        }

        protected override void Voltar(object sender, EventArgs e) {
            if (interacao.Aceitou) {
                RedirecionarPara($"~/Passos/Proposta.aspx?id={interacao.Id}");
            } else {
                RedirecionarPara($"~/Passos/Rebate.aspx?id={interacao.Id}");
            }
        }
        //
        protected override bool Salvar() {

            foreach (ListItem i in Validacoes.Items) {
                if (i.Selected) {
                    var validacao = _roteiroServices.PegarValidacao(i.Value);
                    interacao.MarcarValidacao(validacao);
                } else {
                    return false;
                }
            }

            interacao.ConcluirVenda();

            return base.Salvar();
        }
    }
}