using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IRecusa : ITentativa {
        IObjecao Objecao { get; }
        IList<IObjecao> Objecoes { get; }
        void InformarMotivoRejeicao(Identity idObjecao);
        string PegarContraArgumento(Identity idObjecao);
    }
}
