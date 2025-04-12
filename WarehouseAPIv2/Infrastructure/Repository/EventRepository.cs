using System.Linq.Expressions;
using WarehouseAPIv2.Domain.Aggregate.EventAggregate;
using WarehouseAPIv2.Domain.Repositories;
using WarehouseAPIv2.Infrastructure.Data;

namespace WarehouseAPIv2.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly WarehousesDbContext context;

        public EventRepository(WarehousesDbContext warehousesDbContext)
        {
            this.context = warehousesDbContext;
        }
        public async Task<Event> AddAsync(Event entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AddAsync(List<Event> events)
        {
            context.AddRange(events);
            await context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Event> GetAll(Expression<Func<Event, bool>> predicate)
        {
            return context.Events.Where(predicate).ToList();
        }

    }
}
