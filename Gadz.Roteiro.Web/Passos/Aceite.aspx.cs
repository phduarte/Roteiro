using Gadz.Roteiro.Core;
using System;
using System.Web.UI.WebControls;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Aceite : Passo {

        RoteiroServices _services = RoteiroServices.Instance;

        protected void Page_Load(object sender, EventArgs e) {
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
            Validacoes.DataSource = _services.ListarValidacoes(Interacao.Campanha);
            Validacoes.DataBind();
        }

        protected override void Voltar(object sender, EventArgs e) {
            if (Interacao.Aceitou) {
                RedirecionarPara($"~/Passos/Proposta.aspx?id={Interacao.Id}");
            } else {
                RedirecionarPara($"~/Passos/Rebate.aspx?id={Interacao.Id}");
            }
        }
        //
        protected override bool Salvar() {

            foreach (ListItem i in Validacoes.Items) {
                if (i.Selected) {
                    Interacao.MarcarValidacao(i.Value);
                } else {
                    return false;
                }
            }

            Interacao.ConcluirVenda();

            return base.Salvar();
        }
    }
}