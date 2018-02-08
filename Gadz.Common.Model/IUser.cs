namespace Gadz.Common.Model {
    public interface IUser : IEntity {
        string Username { get; }
        Name Nome { get; }
        string Perfil { get; }

        bool Validar(string pass);
    }
}
