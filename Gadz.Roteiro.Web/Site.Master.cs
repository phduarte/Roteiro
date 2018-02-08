using System;
using System.Web.UI;

namespace Gadz.Roteiro.Web {

    /// <summary>
    /// 
    /// </summary>
    public partial class Site : MasterPage {
        //
        protected void Page_Init(object sender, EventArgs e) {

        }
        //
        protected void Page_Load(object sender, EventArgs e) {
            Page.Header.DataBind();
        }
    }
}