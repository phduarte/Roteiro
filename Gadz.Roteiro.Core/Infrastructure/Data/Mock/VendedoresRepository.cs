using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {
    internal class VendedoresRepository : IVendedoresRepository {

        static IList<IVendedor> _cache = LoadCache();

        private static List<IVendedor> LoadCache() {
            var lista = new List<IVendedor>();
            var campanhas = new CampanhasRepository();

            var vendedor1 = new Vendedor(Identity.Create()) { Nome = "ADMINISTRADOR", Perfil = "M", Username = "admin", Password = "admin" };
            var vendedor2 = new Vendedor(Identity.Create()) { Nome = new Name("Paulo Henrique", "Fernandes Duarte"), Perfil = "A", Username = "pduarte", Password = "123456" };
            var vendedor3 = new Vendedor(Identity.Create()) { Nome = new Name("YAN", "HENRIQUE DUARTE"), Perfil = "A", Username = "yan", Password = "123" };

            vendedor1.Campanhas = campanhas.GetAllOf(vendedor1).ToList();
            vendedor2.Campanhas = campanhas.GetAllOf(vendedor2).ToList();
            vendedor3.Campanhas = campanhas.GetAllOf(vendedor3).ToList();

            lista.Add(vendedor1);
            lista.Add(vendedor2);
            lista.Add(vendedor3);

            return lista;
        }

        public IVendedor Find(string username) {
            return _cache.First(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public IVendedor Get(Identity id) {
            return _cache.First(x => x.Id.Equals(id));
        }

        public IEnumerable<IVendedor> GetAllOf(ICampanha campanha) {
            return _cache.Where(x => x.Campanhas.Contains(campanha));
        }

        public bool Validate(string username, string password) {

            var vendedor = _cache.First(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (vendedor == null)
                return false;

            return vendedor.Validar(password);
        }
    }
}
