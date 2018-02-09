using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Vendedores {
    public interface IVendedoresRepository : IRepositoryReadOnly<IVendedor>, IRepositoryRelationFor<IVendedor, ICampanha> {

        IVendedor Find(string username);
        bool Validate(string username, string password);
    }
}
