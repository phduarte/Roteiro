namespace Gadz.Roteiro.Core.DomainModel.Clientes {
    public struct Documento {
        public string Tipo, Numero;

        public Documento(string tipo, string numero) {
            Tipo = tipo;
            Numero = numero;
        }

        public override string ToString() {
            return $"[{Tipo}: {Numero}]";
        }
    }
}