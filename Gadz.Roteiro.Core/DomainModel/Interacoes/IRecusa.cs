using Gadz.Roteiro.Core.DomainModel.Objecoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IRecusa : ITentativa {
        IList<IObjecao> Objecoes { get; }
        void InformarMotivoRejeicao(IObjecao idObjecao);
        void RecusarContraProposta();
    }
}
