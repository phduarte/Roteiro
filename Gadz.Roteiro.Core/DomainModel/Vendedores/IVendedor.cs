using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Vendedores {
    public interface IVendedor : IUser {

        IList<ICampanha> Campanhas { get; }

        IInteracao IniciarInteracao(ICampanha campanha);
    }
}
