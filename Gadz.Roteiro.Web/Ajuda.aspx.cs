using System;

namespace Gadz.Roteiro.Web {
    public partial class Ajuda : Pagina {
        protected void Page_Load(object sender, EventArgs e) {
            Rota.Definir("<a href='../Default.aspx'>Início</a> > Ajuda");
        }
    }
}