using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel {
    public abstract class Usuario : Entity, IUser {

        public Name Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Perfil { get; set; }

        protected Usuario() {

        }

        protected Usuario(Identity id) : base(id) {

        }

        public static IUser Vazio() {
            return new UsuarioVazio();
        }

        public bool Validar(string pass) {
            return Password.Equals(pass);
        }

        public override string ToString() {
            return Nome;
        }
    }
}
