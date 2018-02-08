using System;
using System.Web.UI.WebControls;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Rebate : Passo {
        //
        protected void Page_Load(object sender, EventArgs e) {

            if (Interacao == null)
                Response.Redirect("~");

            LbContraArgumento.Text = "";

            if (!IsPostBack) {
                Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Rebate");

                ListarMotivos();
                Preencher();
                ValidarSituacaoOferta();

            }
        }
        //
        void ValidarSituacaoOferta() {

            if (CmbAceitou.SelectedValue.Equals("1")) {

                string _direcao = "0";

                if (Request.QueryString != null && Request.QueryString["d"] != null) {
                    _direcao = Request.QueryString["d"];
                    if (_direcao.Equals("1")) {
                        Avancar();
                    }  else if (_direcao.Equals("-1"))
                        Voltar();
                }
            }
        }
        //
        void ListarMotivos() {

            CmbMotivo.Items.Add("Selecione...");

            foreach(var i in Interacao.Objecoes) {
                CmbMotivo.Items.Add(new ListItem(i.Motivo, i.Id));
            }
        }
        //
        protected void Preencher(object sender, EventArgs e) {
            LbContraArgumento.Text = Interacao.PegarContraArgumento(CmbMotivo.SelectedValue);
        }
        //
        private void Terminar(object sender, EventArgs e) {
            base.Terminar();
        }
        //
        private void Preencher() {

            if (Interacao.Objecao == null)
                return;

            CmbMotivo.SelectedValue = Interacao.Objecao.Id.ToString();
            LbContraArgumento.Text = Interacao.Objecao.ContraArgumento;
            CmbAceitou.SelectedValue = Interacao.Aceitou.ToString() ;
        }
        //
        protected override void Avancar(object sender, EventArgs e) {

            Interacao.InformarMotivoRejeicao(CmbMotivo.SelectedValue);

            if (Salvar()) {
                if (CmbAceitou.SelectedValue.Equals("0")) {
                    Terminar(sender, e);
                } else {
                    Avancar();
                }
            } else {
                Msgbox.Show("Não foi possível avançar.");
            }
        }
        //
        protected override bool Salvar() {

            if (CmbAceitou.SelectedValue.Equals("1")) {
                Interacao.AceitarProposta();
            } else {
                Interacao.RejeitarProposta();
            }

            return base.Salvar();
        }
    }
}