namespace Gadz.Roteiro.DomainModel {
    public interface IUsuariosRepository {
        bool Validate(string username, string password);
        void UpdatePassword(string username, string password);
        void Inactivate(string username);
        void Activate(string username);
    }
}
