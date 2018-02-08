using System;
using System.Web.UI;

namespace Gadz.Roteiro.Web.Vendedores {

    public partial class Pesquisar : Pagina {

        protected void Page_Load(object sender, EventArgs e) {

            if(!App.CurrentUser.Perfil.Equals("B")) {

                if(!Page.IsPostBack) {

                    Rota.Definir("<a href='../Default.aspx'>Início</a> > Vendedores");

                    ListarGrupos(sender, e);
                    ListarSupervisores(sender, e);
                    Preencher(sender, e);
                }
            }
        }
        protected void Preencher(object sender, EventArgs e) {

            //string _sql = "select top 100 Id,Username,Nome,Perfil,Situacao "
            //            + "from vw_Usuarios "
            //            + "order by nome";

            //Tabela.Preencher(_sql);
        }

        protected void ListarGrupos(object sender, EventArgs e) {

            ListarGrupos();
            Preencher(sender, e);
        }

        protected void ListarGrupos() {

            //string sql = "select grupo from vw_cadastro group by grupo order by grupo";

            //CmbGrupo.Listar(sql, "Todos");
        }

        protected void ListarSupervisores(object sender, EventArgs e) {

            ListarSupervisores();
            Preencher(sender, e);
        }

        protected void ListarSupervisores() {

            //string sql;

            //sql = "select superior1 "
            //    + "from vw_cadastro "
            //    + "where perfil='B' and grupo like '" + CmbGrupo.SelectedValue + "%' "
            //    + "group by superior1 "
            //    + "order by superior1";

            //CmbSupervisor.Listar(sql, "Todos");
        }
    }
}