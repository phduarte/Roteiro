namespace Gadz.Roteiro.Core.DomainModel.Interacoes {
    public interface IStatusInteracao {
        string Nome { get; }
        bool Ofertada { get; }
        bool Recusada { get; }
        bool Aceite { get; }
        bool Vendida { get; }
        bool Concluida { get; }
    }
}