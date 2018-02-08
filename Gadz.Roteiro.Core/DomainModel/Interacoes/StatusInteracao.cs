using System;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public abstract class StatusInteracao : IStatusInteracao {
        public abstract string Nome { get; }
        public virtual bool Ofertada => false;
        public virtual bool Recusada => false;
        public virtual bool Aceite => false;
        public virtual bool Vendida => false;
        public virtual bool Concluida => false;

        public static implicit operator string(StatusInteracao statusInteracao) {
            return statusInteracao.ToString();
        }

        public static IStatusInteracao Parse(string status) {
            switch (status.ToLower()) {
                case "abordagem": return new StatusInteracaoAbordagem();
                case "aceite": return new StatusInteracaoAceite();
                case "proposta": return new StatusInteracaoProposta();
                case "rebate": return new StatusInteracaoRebate();
                case "recusa": return new StatusInteracaoRecusada();
                case "sondagem": return new StatusInteracaoSondagem();
                case "venda": return new StatusInteracaoVendido();
            }
            throw new NotImplementedException(nameof(status));
        }

        public override string ToString() {
            return Nome;
        }
    }
}
