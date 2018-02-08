using System;
using System.Web.UI.WebControls;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Sondagem : Passo {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Sondagem");
                Preencher();
            }
        }
        //
        void Preencher() {
            
            foreach (var premissa in Interacao.Premissas) {

                var _painel = new Panel() {
                    CssClass = "premissa"
                };
                _painel.Controls.Add(new Label { Text = premissa.Pergunta });

                switch (premissa.Tipo) {
                    case Core.DomainModel.Premissas.TipoPremissa.textbox:
                        var textbox = new TextBox {
                            ID = premissa.Id,
                            CssClass = "color3 border2 " + premissa.Classe,
                            ClientIDMode = System.Web.UI.ClientIDMode.Static,
                            Text = premissa.Resposta
                        };
                        _painel.Controls.Add(textbox);
                        break;
                    case Core.DomainModel.Premissas.TipoPremissa.dropdownlist:

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
                    Interacao.ResponderPremissa(idPremissa, Request.Form[i]);
                }
            }

            return base.Salvar();
        }
    }
}