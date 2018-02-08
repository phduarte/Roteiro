namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public class StatusInteracaoAceite : StatusInteracao {

        public override string Nome => "Aceite";
        public override bool Ofertada => true;
        public override bool Aceite => true;
    }
}
