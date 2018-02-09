using Gadz.Roteiro.Core.DomainModel.Objecoes;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Rebate : Passo {

        IList<IObjecao> _objecoes;

        //
        protected void Page_Load(object sender, EventArgs e) {


            if (interacao == null)
                Response.Redirect("~");

            _objecoes = interacao.Campanha.Objecoes;

            if (_objecoes.Count == 0) {
                Pular();
            }

            LbContraArgumento.Text = string.Empty;

            Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Rebate");

            if (!IsPostBack) {
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
                    } else if (_direcao.Equals("-1"))
                        Voltar();
                }
            }
        }
        //
        void ListarMotivos() {

            CmbMotivo.Items.Add("Selecione...");

            foreach (var i in _objecoes) {
                CmbMotivo.Items.Add(new ListItem(i.Motivo, i.Id));
            }
        }
        //
        protected void Preencher(object sender, EventArgs e) {
            var objecao = _roteiroServices.PegarObjecao(CmbMotivo.SelectedValue);
            LbContraArgumento.Text = objecao.ContraArgumento;
        }
        //
        private void Terminar(object sender, EventArgs e) {
            base.Terminar();
        }
        //
        private void Preencher() {

            if (interacao.Objecoes.Count == 1) {
                CmbMotivo.SelectedValue = interacao.Objecoes[0].Id.ToString();
                LbContraArgumento.Text = interacao.Objecoes[0].ContraArgumento;
            }

            CmbAceitou.SelectedValue = interacao.Aceitou.ToString();
        }
        //
        protected override void Avancar(object sender, EventArgs e) {

            var motivo = _roteiroServices.PegarObjecao(CmbMotivo.SelectedValue);

            interacao.InformarMotivoRejeicao(motivo);

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
                interacao.AceitarProposta();
            } else {
                interacao.RecusarContraProposta();
            }

            return base.Salvar();
        }
    }
}