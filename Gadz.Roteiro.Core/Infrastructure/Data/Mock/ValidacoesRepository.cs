﻿using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {
    internal class ValidacoesRepository : IValidacoesRepository {

        static IList<IValidacao> _cache = new List<IValidacao>{
            new Validacao { Texto = "CPF do cliente é valido de acordo com o site da receita federal." },
            new Validacao { Texto = "Cliente não contém restrição no siste XPTO." },
            new Validacao { Texto = "Cliente não possui promoção que restrinja sua participação nesse plano." },
            new Validacao { Texto = "Cliente está ciente que a promoção não é cumulativa." },
            new Validacao { Texto = "Cliente está ciente de que os descontos são válidos para os 3 primeiros meses." }
        };

        public IValidacao Get(Identity id) {
            return _cache.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<IValidacao> GetAllOf(ICampanha campanha) {
            return _cache;
        }

        public IEnumerable<IValidacao> GetAllOf(IInteracao entity) {
            return _cache;
        }
    }
}
