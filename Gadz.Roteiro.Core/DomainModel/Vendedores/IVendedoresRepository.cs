using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Vendedores {
    public interface IVendedoresRepository : IRepositoryRelationFor<IVendedor,ICampanha>, IRepositoryReadOnly<IVendedor> {
        IVendedor Find(string username);
        bool Validate(string username, string password);
    }
}
