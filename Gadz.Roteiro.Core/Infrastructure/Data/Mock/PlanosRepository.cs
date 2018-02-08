using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Planos;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {

    internal class PlanosRepository : IPlanosRepository {

        static BeneficiosRepository beneficios = new BeneficiosRepository();

        static IList<IPlano> _cache = LoadCache();

        public IEnumerable<IPlano> GetAllOf(ICampanha campanha) {
            return _cache;
        }

        public IPlano Get(Identity id) {
            return _cache.FirstOrDefault(x => x.Id.Equals(id));
        }

        private static List<IPlano> LoadCache() {
            var lista = new List<IPlano>();


            var plano1 = new Plano(Identity.Create()) { Nome = "Plano 1", Descricao = "Clientes que gastam até 100 por mês", GastoMensal = 100, Preco = 120L };
            var plano2 = new Plano(Identity.Create()) { Nome = "Plano 1", Descricao = "Plano 2", GastoMensal = 200, Preco = 120L };
            var plano3 = new Plano(Identity.Create()) { Nome = "Plano 1", Descricao = "Plano 3", GastoMensal = 50, Preco = 120L };
            var plano4 = new Plano(Identity.Create()) { Nome = "Plano 1", Descricao = "Plano 4", GastoMensal = 75, Preco = 120L };
            var plano5 = new Plano(Identity.Create()) { Nome = "Plano 1", Descricao = "Plano 5", GastoMensal = 90, Preco = 120L };

            plano1.Beneficios = beneficios.GetAllOf(plano1).ToList();
            plano2.Beneficios = beneficios.GetAllOf(plano2).ToList();
            plano3.Beneficios = beneficios.GetAllOf(plano3).ToList();
            plano4.Beneficios = beneficios.GetAllOf(plano4).ToList();
            plano5.Beneficios = beneficios.GetAllOf(plano5).ToList();

            lista.Add(plano1);
            lista.Add(plano2);
            lista.Add(plano3);
            lista.Add(plano4);
            lista.Add(plano5);

            return lista;
        }
    }
}
