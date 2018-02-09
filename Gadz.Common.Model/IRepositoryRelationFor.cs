using System.Collections.Generic;

namespace Gadz.Common.Model {
    public interface IRepositoryRelationFor<A, B> where A: IEntity where B: IEntity {
        IEnumerable<A> GetAllOf(B entity);
    }
}
