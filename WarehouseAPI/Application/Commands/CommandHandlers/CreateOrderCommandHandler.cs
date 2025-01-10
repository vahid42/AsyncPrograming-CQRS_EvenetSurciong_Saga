
using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Commands.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateProductCommand, Product>
    {
        public Task<Product> HandleAsync(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
