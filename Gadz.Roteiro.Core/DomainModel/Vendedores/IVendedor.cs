using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel.Vendedores {
    public interface IVendedor : IUser {
        IList<ICampanha> Campanhas { get; }
    }
}
