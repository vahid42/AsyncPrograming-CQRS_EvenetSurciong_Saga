using WarehouseAPIv2.Domain.DomainService;

namespace WarehouseAPIv2.Domain.Aggregate.ProductAggregate
{
    public class ProductFactory
    {
        private readonly IProductDomainService _domainService;

        public ProductFactory(IProductDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<Product> CreateProductAsync(string productName, string universalProductCode, ProductType productType, string? description, CompanyInformation companyInformation)
        {
            return await Product.CreateAsync(productName, universalProductCode, productType, description, companyInformation,  _domainService);
        }
    }
}
