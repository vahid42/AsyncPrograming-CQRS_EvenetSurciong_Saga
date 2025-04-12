using System.Linq.Expressions;
using WarehouseAPIv2.Domain.Aggregate.EventAggregate;
using WarehouseAPIv2.Domain.Base;

namespace WarehouseAPIv2.Domain.Repositories
{
    public interface IEventRepository 
    {
        Task<bool> AddAsync(List<Event> events);
        IEnumerable<Event> GetAll(Expression<Func<Event, bool>> predicate);
        Task<Event> AddAsync(Event entity);

    }
}
