using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Campanhas {

    internal class Campanha : Entity, ICampanha {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public string Abordagem { get; set; }

        public IList<IObjecao> Objecoes { get; set; } = new List<IObjecao>();
        public IList<IPlano> Planos { get; set; } = new List<IPlano>();
        public IList<IPremissa> Premissas { get; set; } = new List<IPremissa>();
        public IList<IValidacao> Validacoes { get; set; } = new List<IValidacao>();

        public Campanha() {
        }

        public Campanha(Identity id) : base(id) {
        }

        public override string ToString() {
            return Nome;
        }
    }
}