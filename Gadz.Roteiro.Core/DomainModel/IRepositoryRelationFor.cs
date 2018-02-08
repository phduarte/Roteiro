using Gadz.Common.Model;
using System.Collections.Generic;

namespace Gadz.Roteiro.Core.DomainModel {
    public interface IRepositoryRelationFor<A, B> where A: IEntity where B: IEntity {
        IEnumerable<A> GetAllOf(B entity);
    }
}
