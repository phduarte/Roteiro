namespace Gadz.Common.Model {
    public struct Name {

        public string FirstName, LastName;

        public Name(string name) {
            FirstName = name;
            LastName = name;
        }

        public Name(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;
        }

        public static implicit operator string(Name name) {
            return name.ToString();
        }

        public static implicit operator Name(string name) {
            return new Name(name);
        }

        public override string ToString() {

            if (FirstName == null)
                return string.Empty;

            if (FirstName.Equals(LastName))
                return FirstName;

            return $"{FirstName} {LastName}";
        }
    }
}
