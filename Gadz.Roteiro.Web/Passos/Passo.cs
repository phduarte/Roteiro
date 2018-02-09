using Gadz.Roteiro.Core;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gadz.Roteiro.Web.Passos {

    public abstract class Passo : Pagina {

        IList<string> passos = new List<string> { "Iniciar", "Abordagem", "Sondagem", "Proposta", "Rebate", "Aceite", "Terminar" };
        protected RoteiroServices _roteiroServices;

        public string CampanhaAtual => interacao != null ? interacao.Campanha.Nome : string.Empty;
        public string UltimaPaginaVisualizada => $"~/Passos/{interacao?.Status}.aspx?id={interacao?.Id}";
        protected IInteracao interacao;

        #region Page Components

        protected global::System.Web.UI.HtmlControls.HtmlImage ImgOperacao;
        protected global::System.Web.UI.HtmlControls.HtmlForm Formulario;
        protected global::System.Web.UI.WebControls.Button BtnVoltar;
        protected global::System.Web.UI.WebControls.Button BtnAvancar;
        protected global::System.Web.UI.WebControls.HiddenField TxtIdInteracao;

        #endregion

        #region ctor
        //
        protected Passo() {
            _roteiroServices = RoteiroServices.Instance;
            Page.Load += new EventHandler(DefinirImagem);
            Page.PreLoad += (sender, e) => { interacao = PegarInteracaoAtual(); };
        }

        #endregion

        #region methods
        //
        protected virtual bool Salvar() {
            _roteiroServices.SalvarInteracao(interacao);
            return true;
        }
        //
        void DefinirImagem(object sender, EventArgs e) {
            //if(ImgOperacao != null && sessao != null)
            //    ImgOperacao.Src = "../../content/img/icons/" + sessao.Operacao + ".png";
        }
        //
        string PaginaSeguinte() {
            return IrPara(1);
        }
        //
        string PaginaAnterior() {
            return IrPara(-1);
        }
        //
        protected void RedirecionarPara(string url) {
            if (string.IsNullOrEmpty(url))
                return;

            Response.Redirect(Page.ResolveUrl(url));
        }
        //
        protected void Terminar() {
            RedirecionarPara($"~/Passos/Terminar.aspx?id={interacao.Id}&d=1");
        }
        //
        protected void Pular() {
            RedirecionarPara(IrPara(1));
        }
        //
        string IrPara(int movimento) {

            string _atual = PassoAtual();

            if (_atual.Contains(passos[0]))
                return "";

            int x = PegarPosicao(_atual) + movimento;

            if (x > (passos.Count - 1))
                x = passos.Count - 1;

            return string.Format("~/Passos/{0}.aspx?id={1}&d={2}", passos[x], interacao.Id, movimento);
        }
        //
        protected void Avancar() {
            RedirecionarPara(PaginaSeguinte());
        }
        //
        protected void Voltar() {
            RedirecionarPara(PaginaAnterior());
        }
        //
        protected virtual void Avancar(object sender, EventArgs e) {
            if (Salvar()) {
                Avancar();
            } else {
                Msgbox.Show("Não foi possível avançar.");
            }
        }
        //
        protected virtual void Voltar(object sender, EventArgs e) {
            Voltar();
        }

        protected IInteracao PegarInteracaoAtual() {
            string idInteracaoAtual = PegarParametroQuerystring("id");
            if (!string.IsNullOrEmpty(idInteracaoAtual)) {
                interacao = _roteiroServices.PegarInteracao(idInteracaoAtual);
            }

            return interacao;
        }

        //
        string PassoAtual() {
            return new FileInfo(Request.Url.LocalPath).Name.ToLower();
        }
        //
        int PegarPosicao(string passo) {
            int _retorno = 0;
            for (int i = 0; i < passos.Count; i++) {
                if (passo.ToLower().StartsWith(passos[i].ToLower())) {
                    _retorno = i;
                    break;
                }
            }
            return _retorno;
        }

        #endregion
    }
}