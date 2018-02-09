using Gadz.Roteiro.DomainModel;
using System.Configuration;
using System.Data.SqlClient;

namespace Gadz.Roteiro.Infrastructure {
    internal class UsuariosRepository : IUsuariosRepository {

        protected string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public void Activate(string username) {
            using (var conn = new SqlConnection(connectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = "UPDATE Usuarios SET Ativo = 1 WHERE Username = @Username";
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inactivate(string username) {
            using (var conn = new SqlConnection(connectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = "UPDATE Usuarios SET Ativo = 0 WHERE Username = @Username";
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePassword(string username, string password) {
            using (var conn = new SqlConnection(connectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = "UPDATE Usuarios SET Password = @Password WHERE Username = @Username";
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Validate(string username, string password) {
            using(var conn = new SqlConnection(connectionString)) {
                conn.Open();
                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = "SELECT * FROM Usuarios WHERE Username = @Username AND Password = @Password";
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    using(var rec = cmd.ExecuteReader()) {
                        return rec.HasRows;
                    }
                }
            }
        }
    }
}
