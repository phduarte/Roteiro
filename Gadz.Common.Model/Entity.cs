namespace Gadz.Common.Model {
    public abstract class Entity : IEntity {
        public Identity Id { get; private set; }
        public bool Exists { get; private set; }

        protected Entity(Identity id) {
            Id = id;
            Exists = true;
        }

        protected Entity() {
            Id = Identity.Create();
            Exists = false;
        }

        public override bool Equals(object obj) {

            if (obj is Entity entity) {
                return entity.Id.Equals(Id);
            }

            return false;
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity a, Entity b) {
            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) {
            return !a.Equals(b);
        }
    }
}
