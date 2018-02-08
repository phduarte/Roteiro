using System;
using System.Collections.Generic;

namespace Gadz.Roteiro.Web {

    public class Versao {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public List<string> Solucoes { get; set; }
    }

    public partial class Versoes : Pagina {

        public List<Versao> versoes;

        public Versoes() {
            versoes = new List<Versao>();
        }
        //
        protected void Page_Load(object sender, EventArgs e) {
            Rota.Definir("<a href='Default.aspx'>Início</a> > Versoes");
            if(!IsPostBack){
                Preencher();
            }
        }
        //
        void Preencher() {

            //using (conn = new Connection()) {

            //    string sql = @"select Id, convert(varchar,Versao) + '.' + convert(varchar,Fix) + '.' + convert(varchar,Build) + ' - ' + isnull(Nome,'') as Nome, Solucao, isnull(DataPublicacao,getdate()) as Data
            //                   from Versoes a with(nolock) 
            //                   where a.Visivel = 1
            //                   order by versao desc, fix desc, build desc";

            //    using (SqlDataReader rec = conn.Query(sql)) {

            //        if (rec != null && rec.HasRows) {
                        
            //            //bool _continua = rec.Read();

            //            do {

            //                string _nome = rec["Nome"].ToString();

            //                Versao versao = new Versao() {
            //                    Id = rec["Id"].ToString().ToInt(),
            //                    Nome = _nome,
            //                    Data = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(rec["Data"].ToString())),
            //                    Solucoes = new List<string>()
            //                };

            //                do{
            //                    versao.Solucoes.Add(rec["Solucao"].ToString());
            //                    _continua = rec.Read();
            //                } while (_continua && _nome.Equals(rec["Nome"].ToString()));

            //                versoes.Add(versao);

            //            } while (_continua);
            //        }
            //    }
            //}
        }
    }
}