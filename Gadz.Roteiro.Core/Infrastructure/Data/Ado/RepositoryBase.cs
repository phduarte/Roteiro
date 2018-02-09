using Gadz.Common.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal abstract class RepositoryBase {

        protected string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        protected SqlConnection CreateConnection() {
            return new SqlConnection(connectionString);
        }

        public T Get<T>(string sql, Identity id) where T: IEntity {
            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", id.ToString());

                    using (var rec = cmd.ExecuteReader()) {
                        if (rec.Read()) {
                            return Map<T>(rec);
                        }
                    }
                }
            }

            return default(T);
        }

        public IEnumerable<T> GetAllOf<T>(string sql, IEntity entity) where T:IEntity {

            using (var conn = CreateConnection()) {

                conn.Open();

                using (var cmd = conn.CreateCommand()) {

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", entity.Id.ToString());

                    using (var rec = cmd.ExecuteReader()) {
                        while (rec.Read()) {
                            yield return Map<T>(rec);
                        }
                    }
                }
            }
        }

        protected abstract T Map<T>(SqlDataReader rec) where T : IEntity;
    }
}
