using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {

    internal class CampanhasRepository : ICampanhasRepository {
        
        static IList<ICampanha> _cache = LoadCache();

        public IEnumerable<ICampanha> GetAllOf(IVendedor vendedor) {
            return _cache;
        }

        public ICampanha Get(Identity id) {
            return _cache.First(x => x.Id.Equals(id));
        }

        private static IList<ICampanha> LoadCache() {

            var premissas = new PremissasRepository();
            var objecoes = new ObjecoesRepository();
            var planos = new PlanosRepository();
            var validacoes = new ValidacoesRepository();

            IList<ICampanha> lista = new List<ICampanha>();

            var campanha1 = new Campanha(Identity.Create()) { Nome = "CARNAVAL", Descricao = "Captação de clientes em período de carnaval", Icone = "campanha.png", Abordagem = @"Olá! Meu nome é <nome>.<br>Gostaria de apresentar a você os benefícios de nossa campanha de <campanha> que sem dúvidas irão lhe agradar bastante.<br><br>Podemos conversar?" };
            var campanha2 = new Campanha(Identity.Create()) { Nome = "NATAL", Descricao = "Captação de clientes em período de carnaval", Icone = "campanha.png", Abordagem = @"Olá! Meu nome é <nome>.<br>Gostaria de apresentar a você os benefícios de nossa campanha de <campanha> que sem dúvidas irão lhe agradar bastante.<br><br>Podemos conversar?" };
            var campanha3 = new Campanha(Identity.Create()) { Nome = "REATIVAÇÃO", Descricao = "Captação de clientes em período de carnaval", Icone = "campanha.png", Abordagem = @"Olá! Meu nome é <nome>.<br>Gostaria de apresentar a você os benefícios de nossa campanha de <campanha> que sem dúvidas irão lhe agradar bastante.<br><br>Podemos conversar?" };


            campanha1.Objecoes = objecoes.GetAllOf(campanha1).ToList();
            campanha2.Objecoes = objecoes.GetAllOf(campanha2).ToList();
            campanha3.Objecoes = objecoes.GetAllOf(campanha3).ToList();

            campanha1.Planos = planos.GetAllOf(campanha1).ToList();
            campanha2.Planos = planos.GetAllOf(campanha2).ToList();
            campanha3.Planos = planos.GetAllOf(campanha3).ToList();

            campanha1.Premissas = premissas.GetAllOf(campanha1).ToList();
            campanha2.Premissas = premissas.GetAllOf(campanha2).ToList();
            campanha3.Premissas = premissas.GetAllOf(campanha3).ToList();

            campanha1.Validacoes = validacoes.GetAllOf(campanha1).ToList();
            campanha2.Validacoes = validacoes.GetAllOf(campanha2).ToList();
            campanha3.Validacoes = validacoes.GetAllOf(campanha3).ToList();

            lista.Add(campanha1);
            lista.Add(campanha2);
            lista.Add(campanha3);
            
            return lista;
        }
    }
}
