using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IVenda : ITentativa {
        IPlano PlanoEscolhido { get; }
        void MarcarValidacao(Identity idValidacao);
        IList<IValidacao> Validacoes { get; }
        void ConcluirVenda();
    }
}
