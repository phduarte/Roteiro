using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Clientes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IOferta : ITentativa {
        string Abordagem { get; }
        IList<IPlano> Planos { get; }
        IList<IPremissa> Premissas { get; }
        ICliente Cliente { get; }
        bool Aceitou { get; }

        void EscolherPlano(IPlano plano);
        void ResponderPremissa(IPremissa idPremissa);
        void AceitarProposta();
        void RejeitarProposta();
    }
}
