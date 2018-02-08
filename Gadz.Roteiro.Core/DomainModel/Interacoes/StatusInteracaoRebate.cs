namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public class StatusInteracaoRebate : StatusInteracao {

        public override string Nome => "Rebate";
        public override bool Ofertada => true;
        public override bool Recusada => true;
    }
}
