using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Domain.DomainService
{
    public class ProductDomainService : IProductDomainService
    {
        public ProductDomainService(IWarehouseRepository<Product> repository)
        {
            Repository = repository;
        }

        public IWarehouseRepository<Product> Repository { get; }

        public async Task<bool> ActiveCurrentProductPrice(string UniversalProductCode)
        {
            var item = await Repository.GetByCodeAsync(UniversalProductCode);
            if (item == null) return false;

            return item.ProductPrices.Any(c => c.IsActive);
        }

        public async Task<bool> DuplicateCodeCheck(string UniversalProductCode)
        {
            var item = await Repository.GetByCodeAsync(UniversalProductCode);

            return item != null;
        }
    }
}
