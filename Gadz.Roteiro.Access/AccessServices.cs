using Gadz.Roteiro.DomainModel;
using Gadz.Roteiro.Infrastructure;

namespace Gadz.Roteiro.Access {
    public class AccessServices {

        readonly IUsuariosRepository _usuarios;

        #region singleton pattern

        static AccessServices _instance;

        public static AccessServices Instance => _instance = _instance ?? new AccessServices();

        #endregion

        public AccessServices() {
            _usuarios = new UsuariosRepository();
        }

        public bool ValidarUsuario(string username, string password) {
            return _usuarios.Validate(username, password);
        }
    }
}
