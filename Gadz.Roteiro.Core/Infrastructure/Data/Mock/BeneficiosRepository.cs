using System.Collections.Generic;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Planos;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {

    internal class BeneficiosRepository : IBeneficiosRepository {


        public IEnumerable<IBeneficio> Find(Identity idPlano) {

            //using (conn = new Connection()) {
            //    string sql = @"select Beneficio, Descricao, Icone
            //                   from fn_BeneficiosPlano({0})";

            //    using (SqlDataReader rec = conn.Query(sql, idPlano)) {
            //        if (rec != null && rec.HasRows)
            //            while (rec.Read()) {
            //                lista.Add(new Beneficio() {
            //                    Nome = rec["Beneficio"].ToString(),
            //                    Descricao = rec["Descricao"].ToString(),
            //                    Icone = rec["Icone"].ToString()
            //                });
            //            }
            //    }
            //}
            return new List<IBeneficio>();
        }

        public IEnumerable<IBeneficio> GetAllOf(IPlano plano) {
            return Find(plano.Id);
        }
    }
}
