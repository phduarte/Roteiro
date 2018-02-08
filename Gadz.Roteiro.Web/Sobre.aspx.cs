using System;

namespace Gadz.Roteiro.Web {

    public partial class Sobre : Pagina {

        protected void Page_Load(object sender, EventArgs e) {
            //sessao.Rota = "<a href='Default.aspx'>Início</a> > Sobre";
            Rota.Definir("<a href='Default.aspx'>Início</a> > Sobre");
        }
    }
}