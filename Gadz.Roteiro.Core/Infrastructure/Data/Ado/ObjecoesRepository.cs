using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class ObjecoesRepository : RepositoryBase, IObjecoesRepository {

        public new IObjecao Get(Identity id) {
            return Get<IObjecao>("SELECT * FROM Objecoes WHERE Id = @Id", id);
        }

        public IEnumerable<IObjecao> GetAllOf(ICampanha campanha) {
            return GetAllOf<IObjecao>("SELECT * FROM Objecoes WHERE CampanhaId = @Id", campanha);
        }

        public new IEnumerable<IObjecao> GetAllOf(IInteracao interacao) {
            return GetAllOf<IObjecao>("SELECT a.* FROM Objecoes a INNER JOIN InteracoesObjecoes b on a.Id = b.ObjecaoId where b.InteracaoId = @Id", interacao);
        }

        protected override T Map<T>(SqlDataReader rec) {
            return (T)(object) new Objecao(rec["Id"].ToString()) {
                ContraArgumento = rec["ContraArgumento"].ToString(),
                Motivo = rec["Motivo"].ToString()
            };
        }
    }
}
