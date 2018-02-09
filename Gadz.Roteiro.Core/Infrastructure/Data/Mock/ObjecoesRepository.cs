using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {

    internal class ObjecoesRepository : IObjecoesRepository {

        static IList<IObjecao> _cache = new List<IObjecao> {
            new Objecao(Identity.Create()){ Motivo = "Sem dinheiro", ContraArgumento = "Esse plano é mais barato do que" },
            new Objecao(Identity.Create()){ Motivo = "Não quero mais", ContraArgumento = "Esse plano é mais barato do que" },
            new Objecao(Identity.Create()){ Motivo = "Desempregado", ContraArgumento = "Esse plano é mais barato do que" },
            new Objecao(Identity.Create()){ Motivo = "Cansei disso", ContraArgumento = "Esse plano é mais barato do que" }
        };

        public IObjecao Get(Identity id) {
            return _cache.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<IObjecao> GetAllOf(ICampanha campanha) {
            return _cache;
        }

        public IEnumerable<IObjecao> GetAllOf(IInteracao entity) {
            return _cache;
        }

        public string PegarContraArgumento(Identity idObjecao) {            
            return _cache.FirstOrDefault(x=>x.Id.Equals(idObjecao))?.ContraArgumento;
        }
    }
}
