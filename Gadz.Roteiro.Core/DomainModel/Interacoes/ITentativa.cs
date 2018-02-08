using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface ITentativa : IEntity {
        IVendedor Vendedor { get; }
        IStatusInteracao Status { get; }
        ICampanha Campanha { get; }
        DateTime Inicio { get; }
        DateTime? Termino { get; }

        void IniciarConversar();
        void Terminar();
    }
}
