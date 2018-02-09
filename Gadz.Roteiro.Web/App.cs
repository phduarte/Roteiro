using Gadz.Common.Model;
using Gadz.Roteiro.Core;
using System.Web;

namespace Gadz.Roteiro.Web {
    public class App {

        public static IUser CurrentUser { get {
                return getUser();
            }
        }
        public static string Nome => "Roteiro";
        public static string Versao => "0.1.1";
        public static string Powered => "GADZ";
        public static string EmailSuporte => "phduarte87@outlook.com";

        public static void SerCurrentUser(IUser vendedor) {
            HttpContext.Current.Session["usuario"] = vendedor;
        }

        static IUser getUser() {

            var user = HttpContext.Current.Session["usuario"] as IUser;

            if(user == null && HttpContext.Current.User.Identity.IsAuthenticated) {
                user = RoteiroServices.Instance.PegarVendedorPorUsername(HttpContext.Current.User.Identity.Name);
            }

            return user;
        }

        public static string Autor => "Paulo Duarte";
    }
}