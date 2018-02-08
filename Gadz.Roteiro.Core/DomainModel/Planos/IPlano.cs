using System.Collections.Generic;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Planos {
    public interface IPlano : IEntity {
        string Nome { get; }
        string Descricao { get; }
        decimal GastoMensal { get; }
        decimal GastoMensalOi { get;  }
        decimal GastoMensalOutras { get; }
        string Localidade { get; }
        decimal Preco { get; }
        bool ZonaConcorrencia { get;  }
        IList<IBeneficio> Beneficios { get; }
        PlanoTipo Tipo { get; }
        ICampanha Campanha { get; }
    }
}