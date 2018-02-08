using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {
    internal class PremissasRepository : IPremissasRepository {

        static IList<IPremissa> _cache = new List<IPremissa> {
            new Premissa { Tipo = TipoPremissa.textbox, Pergunta="Quantos anos você tem?" },
            new Premissa { Tipo = TipoPremissa.dropdownlist, Pergunta="Com qual frequência assiste TV?", Padrao = "1 hora por dia. todos os dias,  1 hora por semana, 1 hora por mês" },
            new Premissa { Tipo = TipoPremissa.dropdownlist, Pergunta="Com qual frequência utiliza internet?" , Padrao = "1 hora por dia. todos os dias,  1 hora por semana, 1 hora por mês"}
        };

        public IEnumerable<IPremissa> GetAllOf(ICampanha campanha) {
            return _cache.OrderBy(x=>x.Ordem).ToList();
        }
    }
}
