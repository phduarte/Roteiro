using System.Collections.Generic;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;

namespace Gadz.Roteiro.Core.DomainModel.Planos {
    public interface IPlano : IEntity {
        string Nome { get; }
        string Descricao { get; }
        decimal Preco { get; }
        IList<IBeneficio> Beneficios { get; }
        PlanoTipo Tipo { get; }
    }
}