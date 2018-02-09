using System;
using System.Collections.Generic;
using Gadz.Roteiro.Core.DomainModel.Planos;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Proposta : Passo {

        protected string argumentos = "";
        protected string arvore = "";
        protected IList<IPlano> planos = new List<IPlano>();

        protected void Page_Load(object sender, EventArgs e) {

            if (interacao == null)
                Response.Redirect("~");

            if (!IsPostBack) {

                Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Proposta");

                TxtGastoMensal.Value = "0";
                TxtPlanoId.Value = "0";
                CmbAceitou.SelectedValue = "0";
                TxtLocalidade.Value = "";
                Preencher();
                PreencherArvore();
            }
        }
        //
        protected override void Avancar(object sender, EventArgs e) {
            if (TxtPlanoId.Value.Equals("0")) {
                Msgbox.Show("Clique sobre o plano que foi ofertado.");
                Preencher();
                PreencherArvore();
            } else {

                var plano = _roteiroServices.PegarPlano(TxtPlanoId.Value);

                interacao.EscolherPlano(plano);

                Salvar();
                Response.Redirect($"~/Passos/{interacao.Status}.aspx?id={interacao.Id}");
            }
        }
        //
        protected void Preencher() {

            planos = interacao.Campanha.Planos;

            if (interacao.Planos.Count == 1) {
                TxtPlanoId.Value = interacao.Planos[0].Id;
            }

            CmbAceitou.SelectedValue = interacao.Aceitou ? "1" : "0";
        }
        //
        protected void PreencherArvore() {

            string[] _campos = { };

            foreach (IPlano plano in planos) {
                Array.Resize(ref _campos, _campos.Length + 1);
                _campos[_campos.Length - 1] = "{\"id\" : \"" + plano.Id + "\",\"valor\" : \"" + plano.Preco + "\"}";
            }

            arvore = "[" + string.Join(",", _campos) + "]";
        }
        //
        protected override bool Salvar() {

            if (CmbAceitou.SelectedValue.Equals("1")) {
                interacao.AceitarProposta();
            } else {
                interacao.RejeitarProposta();
            }

            return base.Salvar();
        }
    }
}