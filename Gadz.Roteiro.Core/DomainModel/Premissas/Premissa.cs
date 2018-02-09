using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Premissas {
    internal class Premissa : Entity, IPremissa {

        public TipoPremissa Tipo { get; set; }
        public string Classe { get; set; }
        public string Padrao { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Ordem { get; set; }

        public Premissa() {

        }

        public Premissa(Identity id) : base(id) {

        }

        public override string ToString() {
            return Pergunta;
        }

        public void Responder(string resposta) {
            Resposta = resposta;
        }
    }
}
