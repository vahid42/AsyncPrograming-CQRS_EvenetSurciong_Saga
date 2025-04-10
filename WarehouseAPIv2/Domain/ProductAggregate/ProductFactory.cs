﻿using WarehouseAPIv2.Domain.DomainService;

namespace WarehouseAPIv2.Domain.ProductAggregate
{
    public class ProductFactory
    {
        private readonly IProductDomainService _domainService;

        public ProductFactory(IProductDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<Product> CreateProductAsync(string productName, string universalProductCode, ProductType productType, string? description, CompanyInformation companyInformation,ProductPrice productPrice,ProductDiscountPrice productDiscountPrice)
        {
            return await Product.CreateAsync(productName, universalProductCode, productType, description, companyInformation,productPrice,productDiscountPrice, _domainService);
        }
    }
}
