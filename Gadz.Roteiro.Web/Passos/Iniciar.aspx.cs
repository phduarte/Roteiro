using System;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Web.Passos {

    public partial class Iniciar : Passo {

        protected void Page_Load(object sender, EventArgs e) {
            
            if (Request.QueryString != null) {

                if (interacao == null) {

                    string idCampanha = PegarParametroQuerystring("c");

                    if (string.IsNullOrWhiteSpace(idCampanha))
                        Response.Redirect("~");

                    if (VerificarInteracaoPendente(idCampanha, out IInteracao interacaoPendente)) {
                        interacao = interacaoPendente;
                    } else {
                        interacao = CriarNovaInteracao(idCampanha);
                    }
                }

                RedirecionarPara(UltimaPaginaVisualizada);
            }
        }

        //
        bool VerificarInteracaoPendente(string idCampanha, out IInteracao idInteracaoPendente) {

            idInteracaoPendente = _roteiroServices.PegarInteracaoPendente(App.CurrentUser.Id, idCampanha);

            return idInteracaoPendente != null;
        }
        //
        IInteracao CriarNovaInteracao(string idCampanha) {

            var vendedor = _roteiroServices.PegarVendedorPorUsername(User.Identity.Name);
            var campanha = _roteiroServices.PegarCampanha(idCampanha);

            return _roteiroServices.CriarInteracao(vendedor,campanha);
        }

        protected override bool Salvar() {
            interacao.IniciarConversar();
            return base.Salvar();
        }
    }
}