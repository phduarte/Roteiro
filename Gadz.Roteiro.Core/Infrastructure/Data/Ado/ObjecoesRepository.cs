using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class ObjecoesRepository : RepositoryBase, IObjecoesRepository {

        ICampanhasRepository _campanhas;
        ICampanha _campanha;

        public ObjecoesRepository(ICampanhasRepository campanhas) {
            _campanhas = campanhas;
        }

        public new IObjecao Get(Identity id) {
            return Get<IObjecao>("SELECT * FROM Objecoes WHERE Id = @Id", id);
        }

        public IEnumerable<IObjecao> GetAllOf(ICampanha campanha) {
            _campanha = campanha;
            return GetAllOf<IObjecao>("SELECT * FROM Objecoes WHERE CampanhaId = @Id", _campanha);
        }

        protected override T Map<T>(dynamic rec) {
            return (T)(object) new Objecao(rec["Id"].ToString()) {
                Campanha = _campanha??_campanhas.Get(rec["CampanhaId"].ToString()),
                ContraArgumento = rec["ContraArgumento"].ToString(),
                Motivo = rec["Motivo"].ToString()
            };
        }
    }
}
