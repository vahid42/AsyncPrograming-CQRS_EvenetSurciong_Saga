
using Newtonsoft.Json;
using WarehouseAPIv2.Domain.Aggregate.EventAggregate;
using WarehouseAPIv2.Domain.Aggregate.ProductAggregate;
using WarehouseAPIv2.Domain.Events;
using WarehouseAPIv2.Domain.Repositories;

namespace WarehouseAPIv2.Application.Commands.CommandHandlers
{
    public class UpdateProductActivatedCommandHandler : ICommandHandler<UpdateProductActivatedCommand, bool>
    {
        private readonly IWarehouseRepository<Product> repository;
        private readonly IEventRepository eventRepository;

        public UpdateProductActivatedCommandHandler(IWarehouseRepository<Product> repository, IEventRepository eventRepository)
        {
            this.repository = repository;
            this.eventRepository = eventRepository;
        }
        public async Task<bool> HandleAsync(UpdateProductActivatedCommand command)
        {
            var events = new List<Event>();

            var product =await repository.GetByIdAsync(command.RequestProductActive.Id);

            if(product == null)
                return false;

            product.ActiveProduct();
            await repository.UpdateAsync(product);

            events.AddRange(from DomainEvent item in product.DomainEvents
                            select new Event(product.Id, item.Nameof, JsonConvert.SerializeObject(item)));

            await eventRepository.AddAsync(events);
            product.ClearDomainEvent();

            return true;

        }
    }
}
