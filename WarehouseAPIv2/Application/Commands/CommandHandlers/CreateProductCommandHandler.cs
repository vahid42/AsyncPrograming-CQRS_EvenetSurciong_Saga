using WarehouseAPIv2.Comman.Dtos;
using WarehouseAPIv2.Domain.DomainService;
using WarehouseAPIv2.Domain.ProductAggregate;
using WarehouseAPIv2.Domain.Repositories;

namespace WarehouseAPIv2.Application.Commands.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ResposeProductDto>
    {
        private readonly IWarehouseRepository<Product> repository;
        private readonly IProductDomainService domainService;

        public CreateProductCommandHandler(IWarehouseRepository<Product> repository, IProductDomainService domainService)
        {
            this.repository = repository;
            this.domainService = domainService;
        }
        public async Task<ResposeProductDto> HandleAsync(CreateProductCommand command)
        {
            var productinfo = command.CreateProductDto;
            var companyInfo = command.CreateProductDto.CompanyInformation;
            var price = command.CreateProductDto.ProductPrice;
            var discount = command.CreateProductDto.ProductDiscountPrice;




            var productFactory = new ProductFactory(domainService);
            var product = await productFactory.CreateProductAsync(
                productinfo?.ProductName,
                productinfo?.UniversalProductCode,
                productinfo.ProductType,
                productinfo.Description,
                new CompanyInformation(companyInfo?.CompanyName, companyInfo?.CompanyAddress, companyInfo?.CompanyPhone, companyInfo?.CompanyEmail, companyInfo?.MadeCountry),
                new ProductPrice(price.PurchasePrice, price.PercentageProfitPrice, price.Quantity),
                new ProductDiscountPrice(discount.OriginalPrice, discount.StartDiscount, discount.EndDiscount, discount.DiscountPercentage)
                );

            var result = await repository.AddAsync(product);

            return new ResposeProductDto()
            {
                Id = result.Id,
                CreateDatetime = result.CreateDatetime,
                Description = result.Description,
                IsActive = result.IsActive,
                ProductName = result.ProductName,
                ProductType = result.ProductType,
                UniversalProductCode = result.UniversalProductCode,
                CompanyInformation = companyInfo,
                ProductDiscountPrice = discount,
                ProductPrice = price
            };
        }
    }
}
