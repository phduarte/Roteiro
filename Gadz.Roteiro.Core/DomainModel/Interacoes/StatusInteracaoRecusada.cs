namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public class StatusInteracaoRecusada : StatusInteracao {

        public override string Nome => "Recusa";
        public override bool Ofertada => true;
        public override bool Recusada => true;
        public override bool Concluida => true;
    }
}
