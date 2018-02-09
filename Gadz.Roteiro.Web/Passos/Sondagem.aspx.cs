using Gadz.Roteiro.Core.DomainModel.Premissas;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Sondagem : Passo {

        IList<IPremissa> _premissas;

        protected void Page_Load(object sender, EventArgs e) {

            if (interacao == null)
                Response.Redirect("~");

            _premissas = interacao.Campanha.Premissas;

            if (_premissas.Count == 0) {
                Pular();
            }

            Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Sondagem");
            if (!IsPostBack) {
                Preencher();
            }
        }
        //
        void Preencher() {

            foreach (var premissa in _premissas) {

                if (interacao.Premissas.Contains(premissa)) {
                    foreach (var i in interacao.Premissas) {
                        if (premissa.Id.Equals(i.Id)) {
                            premissa.Responder(i.Resposta);
                            break;
                        }
                    }
                }

                var _painel = new Panel() {
                    CssClass = "premissa"
                };
                _painel.Controls.Add(new Label { Text = premissa.Pergunta });

                switch (premissa.Tipo) {
                    case TipoPremissa.textbox:
                        var textbox = new TextBox {
                            ID = premissa.Id,
                            CssClass = "color3 border2 " + premissa.Classe,
                            ClientIDMode = System.Web.UI.ClientIDMode.Static,
                            Text = premissa.Resposta
                        };
                        _painel.Controls.Add(textbox);
                        break;
                    case TipoPremissa.dropdownlist:

                        var dropDown = new DropDownList {
                            ID = premissa.Id,
                            CssClass = "color3 border2 " + premissa.Classe,
                            ClientIDMode = System.Web.UI.ClientIDMode.Static,
                            DataSource = premissa.Padrao.Split(',')
                        };

                        if (!string.IsNullOrEmpty(premissa.Resposta))
                            dropDown.SelectedValue = premissa.Resposta;

                        dropDown.DataBind();

                        _painel.Controls.Add(dropDown);

                        break;
                }

                Premissas.Controls.Add(_painel);
            }

        }
        //
        protected override bool Salvar() {

            foreach (string i in Request.Form.AllKeys) {

                if (!i.Contains("ctl00$ContentPlaceHolder1$"))
                    continue;

                var idPremissa = i.Replace("ctl00$ContentPlaceHolder1$", "");

                if (!(idPremissa == "BtnAvancar" || idPremissa == "TxtIdInteracao")) {
                    var premissa = _roteiroServices.PegarPremissa(idPremissa);
                    premissa.Responder(Request.Form[i]);
                    interacao.ResponderPremissa(premissa);
                }
            }

            return base.Salvar();
        }
    }
}