using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Clientes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IOferta : ITentativa {
        string Abordagem { get; }
        IList<IPlano> Planos { get; }
        ICliente Cliente { get; }
        bool Aceitou { get; }
        IList<IPremissa> Premissas { get; }

        void EscolherPlano(Identity plano);
        void ResponderPremissa(Identity idPremissa, string resposta);
        void AceitarProposta();
        void RejeitarProposta();
    }
}
