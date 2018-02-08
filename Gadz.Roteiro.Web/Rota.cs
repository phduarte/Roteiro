using System.Collections.Generic;
using System.Web;

namespace Gadz.Roteiro.Web {
    public class Rota {

        const string ITEM_NAME = "route";

        static IDictionary<string, string> _rotas = new Dictionary<string, string> {
            { "/acesso/alterarsenha.aspx","<a href='../Default.aspx'>Início</a> > Altere sua Senha"}
        };

        public void Adicionar(string rota, string url) {
            _rotas.Add(url, rota);
        }

        public string Pegar(string url) {
            return _rotas[url];
        }

        public void Definir(string rota) {
            if (HttpContext.Current.Items.Contains(ITEM_NAME))
                HttpContext.Current.Items[ITEM_NAME] = rota;
            else
                HttpContext.Current.Items.Add(ITEM_NAME, rota);
        }

        public string Pegar() {

            if (!HttpContext.Current.Items.Contains(ITEM_NAME))
                return string.Empty;

            return HttpContext.Current.Items[ITEM_NAME].ToString();
        }
    }
}