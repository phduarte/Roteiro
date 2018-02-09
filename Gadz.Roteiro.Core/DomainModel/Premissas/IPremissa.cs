using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Premissas {
    public interface IPremissa : IEntity {
        string Pergunta { get; }
        string Resposta { get; }
        string Classe { get; }
        string Padrao { get; }
        int Ordem { get; }
        TipoPremissa Tipo { get; }

        void Responder(string resposta);
    }
}
