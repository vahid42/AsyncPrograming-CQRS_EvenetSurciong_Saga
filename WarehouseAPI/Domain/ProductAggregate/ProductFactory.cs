using WarehouseAPI.Domain.DomainService;

namespace WarehouseAPI.Domain.ProductAggregate
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
            return await Product.CreateAsync(productName, universalProductCode, productType, description, companyInformation, _domainService);
        }
    }
}
