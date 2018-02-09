using System;

namespace Gadz.Common.Model {
    public struct Identity {

        string _id;

        public Identity(string id) {
            _id = id;
        }

        public override string ToString() {
            return _id;
        }

        public static implicit operator string(Identity identity) {
            return identity.ToString();
        }

        public static implicit operator Identity(string id) {
            return new Identity(id);
        }

        public static Identity Create() {
            return new Identity(Guid.NewGuid().ToString());
        }

        public static Identity Create(string id) {
            return new Identity(id);
        }

        public override bool Equals(object obj) {

            if(obj is Identity id) {
                return id.ToString().Equals(_id);
            }

            return false;
        }

        public override int GetHashCode() {
            return _id.GetHashCode();
        }
    }
}
