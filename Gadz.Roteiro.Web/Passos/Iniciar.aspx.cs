using System;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Web.Passos {

    public partial class Iniciar : Passo {
        
        protected void Page_Load(object sender, EventArgs e) {

            if (Request.QueryString != null) {

                string idCampanha = string.Empty,
                       idInteracaoAtual = string.Empty;

                idCampanha = PegarParametroQuerystring("c");
                idInteracaoAtual = PegarParametroQuerystring("id");

                if (string.IsNullOrWhiteSpace(idCampanha) && string.IsNullOrWhiteSpace(idInteracaoAtual))
                    Response.Redirect("~");

                if (!string.IsNullOrEmpty(idInteracaoAtual)) {
                    Interacao = _roteiroServices.PegarInteracao(idInteracaoAtual);
                }
                
                if (VerificarInteracaoPendente(idCampanha, out IInteracao interacaoPendente)) {
                    Interacao = interacaoPendente;
                } else {
                    Interacao = CriarNovaInteracao(idCampanha);
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
            return _roteiroServices.CriarNovaInteracao(App.CurrentUser.Id, idCampanha);
        }

        protected override bool Salvar() {
            Interacao.IniciarConversar();
            return base.Salvar();
        }
    }
}