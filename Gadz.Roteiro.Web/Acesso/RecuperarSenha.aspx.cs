using System;
using System.Web.UI;

namespace Gadz.Roteiro.Web.Acesso {

    public partial class RecuperarSenha : Page {

        protected void Page_Load(object sender, EventArgs e) {
            //txtUsuario.Focus();
        }

        protected void Recuperar(object sender, EventArgs e) {

            //using (conn = new Connection()) {

            //    using (Email mail = new Email()) {

            //        string sql = @"select Email, Senha, Nome
            //                       from Usuarios with(nolock)
            //                       where Username = '{0}'";

            //        using (SqlDataReader rec = conn.Query(sql, txtUsuario.Value)) {

            //            if (rec != null && rec.HasRows && rec.Read()) {
            //                //mail.Servidor = "arezzo.almavivadobrasil.com.br";
            //                mail.De = "pduarte@almavivadobrasil.com.br";
            //                mail.Para = rec[0].ToString();
            //                mail.Mensagem = "A senha do usuário " + rec[2].ToString() + " é " + rec[1].ToString();
            //                mail.Assunto = "Tabulador BOTIM | Recuperação de Senha";

            //                if (mail.Enviar())
            //                    Msgbox.Show("Sua senha foi enviada para seu email.", "Login.aspx");
            //                else
            //                    Msgbox.Show("Não foi possível enviar sua senha");
            //            } else
            //                Msgbox.Show("Usuário não localizado.");
            //        }
            //    }
            //}
        }
    }
}