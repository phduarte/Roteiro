using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel {
    public interface IRepositoryReadOnly<T> where T: IEntity {
        T Get(Identity id);
    }
}
