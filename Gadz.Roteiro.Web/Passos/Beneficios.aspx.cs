using System;
using System.Collections.Generic;
using Gadz.Roteiro.Core;
using Gadz.Roteiro.Core.DomainModel.Beneficios;

namespace Gadz.Roteiro.Web.Passos {

    public partial class Beneficios : Pagina {

        readonly RoteiroServices _services;
        protected IList<IBeneficio> lista = new List<IBeneficio>();

        public Beneficios() {
            _services = RoteiroServices.Instance;
        }
        
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString != null && Request.QueryString["id"] != null) {
                lista = _services.ListarBenfeficiosDoPlano(Request.QueryString["id"]);
            }
        }
    }
}