using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;

namespace Gadz.Roteiro.Core.DomainModel.Validacoes {
    public interface IValidacao : IEntity {
        string Texto { get; set; }
        ICampanha Campanha { get; }
    }
}