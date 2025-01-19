using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Domain.DomainService
{
    public class ProductDomainService: IProductDomainService
    {
        public ProductDomainService(IWarehouseRepository<Product> repository)
        {
            Repository = repository;
        }

        public IWarehouseRepository<Product> Repository { get; }

        public async Task<bool> DuplicateCodeCheck(string code)
        {
            var item= await Repository.GetByCodeAsync(code);

            return item != null;
        }
    }
}
