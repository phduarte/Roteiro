using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class PremissasRepository : RepositoryBase, IPremissasRepository {

        public new IPremissa Get(Identity id) {
            return Get<IPremissa>("SELECT *, null as Resposta FROM Premissas WHERE Id = @Id", id);
        }

        public IEnumerable<IPremissa> GetAllOf(ICampanha campanha) {
            return GetAllOf<IPremissa>("SELECT *, null as Resposta FROM Premissas WHERE CampanhaId = @Id", campanha);
        }

        public IEnumerable<IPremissa> GetAllOf(IInteracao interacao) {
            return GetAllOf<IPremissa>("SELECT a.*, b.Resposta FROM Premissas a INNER JOIN InteracoesPremissas b on a.Id = b.PremissaId where b.InteracaoId = @Id", interacao);
        }

        protected override T Map<T>(SqlDataReader rec) {

            var premissa = new Premissa(rec["Id"].ToString()) {
                Classe = rec["Classe"].ToString(),
                Ordem = int.Parse(rec["Ordem"].ToString()),
                Padrao = rec["Padrao"].ToString(),
                Pergunta = rec["Pergunta"].ToString(),
                Tipo = (TipoPremissa)int.Parse(rec["Tipo"].ToString())
            };

            premissa.Responder(rec["Resposta"].ToString());

            return (T)(object)premissa;
            
        }
    }
}
