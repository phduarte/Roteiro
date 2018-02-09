using Gadz.Roteiro.Core.DomainModel.Validacoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IVenda : ITentativa {
        void MarcarValidacao(IValidacao validacao);
        IList<IValidacao> Validacoes { get; }
        void ConcluirVenda();
    }
}
