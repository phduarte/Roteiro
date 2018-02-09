using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class ValidacoesRepository : RepositoryBase, IValidacoesRepository {

        public IValidacao Get(Identity id) {
            return Get<IValidacao>("SELECT * FROM Validacoes WHERE Id = @Id", id);
        }

        public IEnumerable<IValidacao> GetAllOf(ICampanha campanha) {
            return GetAllOf<IValidacao>("SELECT * FROM Validacoes WHERE CampanhaId = @Id", campanha);
        }

        public IEnumerable<IValidacao> GetAllOf(IInteracao entity) {
            return GetAllOf<IValidacao>("SELECT a.* FROM Validacoes a INNER JOIN InteracoesValidacoes b on a.Id = b.ValidacaoId where b.InteracaoId = @Id", entity);
        }

        protected override T Map<T>(SqlDataReader rec) {
            return (T)(object)new Validacao(rec["Id"].ToString()) {
                Texto = rec["Texto"].ToString()
            };
        }
    }
}
