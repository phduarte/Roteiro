using System;

namespace Gadz.Roteiro.Web.Vendedores {

    public partial class Cadastrar : Pagina {

        protected void Page_Load(object sender, EventArgs e) {

            if(!IsInRole("B")) {

                if(!Page.IsPostBack) {

                    Rota.Definir("<a href='../Default.aspx'>Início</a> > <a href='Default.aspx'>Vendedores</a> > Cadastro");

                    ListarGestores();

                    if(Page.Request.QueryString.Count > 0) {

                        string _idUsuario;

                        _idUsuario = Page.Request.QueryString["i"];

                        if(!string.IsNullOrEmpty(_idUsuario))
                            Preencher(int.Parse(_idUsuario));

                        //TxtUsuario.Focus();
                    }
                }
            }
        }

        protected void ListarGestores() {

            string sql = @"select Id, Nome 
                          from vw_Usuarios 
                          where Perfil <> 'B' 
                          order by Nome";

            //CmbGestor.Listar(sql);
        }

        protected void Preencher(int idUsuario) {

            //using(conn = new Connection()) {

            //    string sql = "select * from vw_Usuarios where Id = {0}";

            //    using (SqlDataReader rec = conn.Query(sql, idUsuario)) {

            //        if (rec != null && rec.HasRows && rec.Read()) {

            //            IdUsuario.Text = idUsuario.ToString();
            //            TxtUsuario.Text = rec["username"].ToString();
            //            TxtNome.Text = rec["nome"].ToString();
            //            CmbPerfil.SelectedValue = rec["perfil"].ToString();
            //            CmbStatus.SelectedValue = rec["situacao"].ToString();
            //            TxtEmail.Text = rec["email"].ToString();

            //            //if (!((sessao.Perfil == "M") || (this.IdUsuario.Text == sessao.IDUsuario.ToString()))) {
            //            if (sessao.Perfil.Equals("B")) {
            //                TxtUsuario.Enabled = false;
            //                TxtNome.Enabled = false;
            //                TxtCargo.Enabled = false;
            //                CmbGestor.Enabled = false;
            //                CmbGrupo.Enabled = false;
            //                CmbPerfil.Enabled = false;
            //                CmbStatus.Enabled = false;
            //                TxtEmail.Enabled = false;
            //                ChkSkills.Enabled = false;
            //            }
            //        }
            //    }
            //}
        }

        protected void Salvar(object sender, EventArgs e) {

            //Message msgbox = new Message(Page);

            //using(conn = new Connection()) {

            //    string _sql, _retorno = "";

            //    _retorno = IdUsuario.Text != "0" ? "UsuariosPesquisar.aspx" : "UsuariosCadastrar.aspx";

            //    _sql = "exec sp_usuarios "
            //        + "@id_usuario = '" + IdUsuario.Text + "',"
            //        + "@usuario = '" + TxtUsuario.Text.Replace("'", "") + "',"
            //        + "@nome = '" + TxtNome.Text.Replace("'", "") + "',"
            //        + "@cargo = '" + TxtCargo.Text.Replace("'", "") + "',"
            //        + "@id_grupo = '" + CmbGrupo.SelectedValue + "',"
            //        + "@id_gestor = '" + CmbGestor.SelectedValue + "',"
            //        + "@perfil = '" + CmbPerfil.SelectedValue + "',"
            //        + "@status = '" + CmbStatus.SelectedValue + "',"
            //        + "@email = '" + TxtEmail.Text.Replace("'", "") + "'";

            //    if(conn.Execute(_sql)) {

            //        _sql = "delete tb_usuarios_skills where id_usuario = '" + IdUsuario.Text + "';";

            //        if(conn.Execute(_sql)) {

            //            foreach(ListItem li in ChkSkills.Items) {
            //                if(li.Selected) {
            //                    _sql = "insert tb_usuarios_skills(id_usuario,id_skill,dt_cadastro) values('" + IdUsuario.Text + "','" + li.Value + "',GETDATE());";
            //                    conn.Execute(_sql);
            //                }
            //            }
            //        }
            //        msgbox.Show("Usuário salvo com sucesso!", _retorno);

            //    } else
            //        msgbox.Show("Erro ao Salvar usuário.");
            //}
        }
    }
}