namespace Gadz.Common.Model {
    public interface IRepositoryReadOnly<T> where T: IEntity {
        T Get(Identity id);
    }
}
