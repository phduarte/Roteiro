namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public class StatusInteracaoVendido : StatusInteracao {

        public override string Nome => "Venda";
        public override bool Ofertada => true;
        public override bool Aceite => true;
        public override bool Vendida => true;
        public override bool Concluida => true;
    }
}
