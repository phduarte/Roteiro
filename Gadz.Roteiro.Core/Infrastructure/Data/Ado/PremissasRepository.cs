using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class PremissasRepository : RepositoryBase, IPremissasRepository {

        ICampanha _campanha;

        public IEnumerable<IPremissa> GetAllOf(ICampanha campanha) {
            _campanha = campanha;
            return GetAllOf<IPremissa>("SELECT * FROM Premissas WHERE CampanhaId = @Id", _campanha);
        }

        protected override T Map<T>(dynamic rec) {

            var premissa = new Premissa(rec["Id"].ToString()) {
                Campanha = _campanha,
                Classe = rec["Classe"].ToString(),
                Ordem = int.Parse(rec["Ordem"].ToString()),
                Padrao = rec["Padrao"].ToString(),
                Pergunta = rec["Pergunta"].ToString(),
                Resposta = rec["Resposta"].ToString(),
                Tipo = (TipoPremissa)int.Parse(rec["Tipo"].ToString())
            };

            return (T)(object)premissa;
            
        }
    }
}
