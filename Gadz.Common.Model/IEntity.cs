namespace Gadz.Common.Model {
    public interface IEntity {
        bool Exists { get; }
        Identity Id { get; }
    }
}