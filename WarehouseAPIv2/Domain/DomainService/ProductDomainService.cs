using WarehouseAPIv2.Domain.Aggregate.ProductAggregate;
using WarehouseAPIv2.Domain.Repositories;

namespace WarehouseAPIv2.Domain.DomainService
{
    public class ProductDomainService : IProductDomainService
    {
        public ProductDomainService(IWarehouseRepository<Product> repository)
        {
            Repository = repository;
        }

        public IWarehouseRepository<Product> Repository { get; }
 

        public async Task<bool> DuplicateCodeCheck(string UniversalProductCode)
        {
            var item = await Repository.GetByCodeAsync(UniversalProductCode);

            return item != null;
        }
    }
}
