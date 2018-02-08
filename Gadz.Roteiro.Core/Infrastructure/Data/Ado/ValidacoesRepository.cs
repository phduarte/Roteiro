using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Ado {
    internal class ValidacoesRepository : RepositoryBase, IValidacoesRepository {

        ICampanha _campanha;

        public IEnumerable<IValidacao> GetAllOf(ICampanha campanha) {
            _campanha = campanha;
            return GetAllOf<IValidacao>("SELECT * FROM Validacoes WHERE CampanhaId = @Id", _campanha);
        }

        protected override T Map<T>(dynamic rec) {
            return (T)(object)new Validacao(rec["Id"].ToString()) {
                Campanha = _campanha,
                Texto = rec["Texto"].ToString()
            };
        }
    }
}
