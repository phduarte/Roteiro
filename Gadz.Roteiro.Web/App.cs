using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel;
using System.Web;

namespace Gadz.Roteiro.Web {
    public class App {

        public static IUser CurrentUser { get {
                
                if (HttpContext.Current.Session["usuario"] is IUser usuario) {
                    return usuario;
                } else {
                    return Usuario.Vazio();
                }
            }
        }
        public static string Nome => "Roteiro";
        public static string Versao => "0.1.1";
        public static string Powered => "GADZ";
        public static string EmailSuporte => "phduarte87@outlook.com";

        public static void SerCurrentUser(IUser vendedor) {
            HttpContext.Current.Session["usuario"] = vendedor;
        }

        public static string Autor => "Paulo Duarte";
    }
}