using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Vendedores;

namespace Gadz.Roteiro.Core.DomainModel.Campanhas {
    public interface ICampanhasRepository : IRepositoryRelationFor<ICampanha,IVendedor>, IRepositoryReadOnly<ICampanha> {
    }
}
