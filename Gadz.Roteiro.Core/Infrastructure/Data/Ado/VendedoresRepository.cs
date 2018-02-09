using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class VendedoresRepository : RepositoryBase, IVendedoresRepository {

        ICampanhasRepository _campanhas;

        public VendedoresRepository(ICampanhasRepository campanhas) {
            _campanhas = campanhas;
        }

        public IVendedor Find(string username) {
            using(var conn = CreateConnection()) {

                conn.Open();

                using(var cmd = conn.CreateCommand()) {

                    cmd.CommandText = "SELECT a.* FROM Usuarios a INNER JOIN Vendedores b on a.Id = b.Id WHERE a.Username = @username";
                    cmd.Parameters.AddWithValue("@username", username);

                    using (var rec = cmd.ExecuteReader()) {
                        if (rec.Read()) {
                            return Map<IVendedor>(rec);
                        }
                    }
                }
            }

            return null;
        }

        public IVendedor Get(Identity id) {
            return Get<IVendedor>("SELECT a.* FROM Usuarios a inner join Vendedores b on a.Id = b.Id WHERE a.Id = @Id", id);
        }

        public IEnumerable<IVendedor> GetAllOf(ICampanha entity) {
            return GetAllOf<IVendedor>("SELECT a.* FROM Usuarios a inner join Vendedores b on a.Id = b.Id inner join VendedoresCampanhas c on b.Id = c.VendedorId WHERE c.CampanhaId = @Id", entity);
        }

        public bool Validate(string username, string password) {
            var u = Find(username);
            return u != null && u.Validar(password);
        }

        protected override T Map<T>(SqlDataReader rec) {

            var vendedor = new Vendedor(rec["Id"].ToString()) {
                Username = rec["Username"].ToString(),
                Password = rec["Password"].ToString(),
                Nome = new Name(rec["Nome"].ToString(),rec["Sobrenome"].ToString()),
                Perfil = rec["Perfil"].ToString()
            };

            vendedor.Campanhas = _campanhas.GetAllOf(vendedor).ToList();

            return (T)(object)vendedor;
        }
    }
}
