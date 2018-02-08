using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Premissas {
    public interface IPremissa : IEntity {
        string Pergunta { get; }
        string Resposta { get; }
        string Classe { get; }
        string Padrao { get; }
        int Ordem { get; }
        TipoPremissa Tipo { get; }
        ICampanha Campanha { get; }

        void Responder(string resposta);
    }
}
