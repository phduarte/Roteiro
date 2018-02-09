using System;
using System.Web;

namespace Gadz.Roteiro.Web {

    public class Global : HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            Application["logados"] = 0;

            Logger.WriteInfo("Aplicação iniciou");
        }

        protected void Session_Start(object sender, EventArgs e) {

            if (int.TryParse(Application["logados"].ToString(), out int i)) {
                Application["logados"] = ++i;
            }

            Logger.WriteInfo($"Sessão {Session.SessionID} iniciou");
        }
        //
        protected void Application_BeginRequest(object sender, EventArgs e) {

            var usuario = Context.User != null ? Context.User.Identity.Name : "undefined";
            var url = Context.Request.Url.PathAndQuery;
            var ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            var sessionId = Context.Request.Cookies["ASP.NET_SessionId"]?.Value;

            Logger.WriteRequest(sessionId, ip, usuario, url);
        }
        //
        protected void Application_Error(object sender, EventArgs e) {

            string _url = "";
            string _msg = "";

            //if (HttpContext.Current.Error.GetType().ToString().Contains("HttpUnhandledException"))
            //    _msg = HttpContext.Current.Error.InnerException.Message;
            //else
            //    _msg = HttpContext.Current.Error.Message;

            if (Request != null && Request.Url != null)
                _url = Request.Url.PathAndQuery;

            _msg = HttpContext.Current.Error.InnerException.InnerException?.Message;

            if (string.IsNullOrEmpty(_msg)) {
                _msg = HttpContext.Current.Error.InnerException.Message;
            }

            if (Context.User != null && Context.User.Identity.IsAuthenticated)
                Logger.WriteError($"Usuário {Context.User.Identity.Name}, ao acessar {_url} reporta {_msg}");
            else
                Logger.WriteError($"Usuário não logado, ao acessar {_url} reporta {_msg}");

#if !DEBUG
            try {
                Server.ClearError();
            } catch (Exception) {
            }

#endif
        }
        //
        protected void Session_End(object sender, EventArgs e) {

            int i = 0;
            int.TryParse(Application["logados"].ToString(), out i);

            i--;

            Application["logados"] = i;

            Logger.WriteInfo($"Sessão {Session.SessionID} terminou");
        }
        //
        protected void Application_End(object sender, EventArgs e) {
            Logger.WriteInfo($"Aplicação {Session.SessionID} terminou");
        }
    }
}