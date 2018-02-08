using System;
using System.Web.UI;

namespace Gadz.Roteiro.Web.Acesso {

    public partial class AlterarSenha : Page {

        protected void Page_Load(object sender, EventArgs e) {

            if(!IsPostBack) {

                //if(sessao.Status == "alterar senha") {
                //    sessao.Rota = "Altere sua senha";
                //} else {
                //    sessao.Rota = "<a href='../Default.aspx'>Início</a> > Altere sua Senha";
                //}

                //txtIdUsuario.Text = sessao.IdUsuario.ToString();
            }
        }

        protected void Alterar(object sender, EventArgs e) {

            //using(conn = new Connection()) {

            //    string sql;

            //    if(!string.IsNullOrEmpty(txtIdUsuario.Text)) {

            //        sql = @"update Usuarios
            //                set Senha = '{0}'
            //                where Id = {1}";

            //        if (conn.Execute(sql, txtSenha.Value, txtIdUsuario.Text)) {
            //            sessao.Status = "logado";
            //            Msgbox.Show("Senha alterada com sucesso.", "Default.aspx");
            //        } else {
            //            Msgbox.Show("Erro ao alterar a senha. \n\nTente novamente ou contate o administrador");
            //        }
            //    } else {
            //        sessao.Status = "deslogado";
            //        Msgbox.Show("Não foi possível alterar sua senha.\n\nContate o Administrador.");
            //    }
            //}
        }
    }
}