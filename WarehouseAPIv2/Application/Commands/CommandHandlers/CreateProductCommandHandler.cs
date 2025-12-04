using Newtonsoft.Json;
using WarehouseAPIv2.Comman.Dtos;
using WarehouseAPIv2.Domain.Aggregate.EventAggregate;
using WarehouseAPIv2.Domain.Aggregate.ProductAggregate;
using WarehouseAPIv2.Domain.DomainService;
using WarehouseAPIv2.Domain.Events;
using WarehouseAPIv2.Domain.Repositories;
using System.Linq;

namespace WarehouseAPIv2.Application.Commands.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ResposeProductDto>
    {
        private readonly IWarehouseRepository<Product> repository;
        private readonly IEventRepository eventRepository;
        private readonly IProductDomainService domainService;

        public CreateProductCommandHandler(IWarehouseRepository<Product> repository,IEventRepository eventRepository, IProductDomainService domainService)
        {
            this.repository = repository;
            this.eventRepository = eventRepository;
            this.domainService = domainService;
        }
        public async Task<ResposeProductDto> HandleAsync(CreateProductCommand command)
        {
            var productinfo = command.CreateProductDto;
            var companyInfo = command.CreateProductDto.CompanyInformation;
            var price = command.CreateProductDto?.ProductPrice;
            var discount = command.CreateProductDto?.ProductDiscountPrice;
            var events = new List<Event>();

            var productFactory = new ProductFactory(domainService);
            var product = await productFactory.CreateProductAsync(
                productinfo?.ProductName,
                productinfo?.UniversalProductCode,
                productinfo.ProductType,
                productinfo.Description,
                new CompanyInformation(companyInfo?.CompanyName, companyInfo?.CompanyAddress, companyInfo?.CompanyPhone, companyInfo?.CompanyEmail, companyInfo?.MadeCountry)
                );
            product.UpdateProductPrice(price.PurchasePrice, price.PercentageProfitPrice, price.Quantity);
            product.UpdateProductDiscountPrice(discount.StartDiscount, discount.EndDiscount, discount.DiscountPercentage);
            product.ActiveProduct();

            var result = await repository.AddAsync(product);

            events.AddRange(from DomainEvent item in product.DomainEvents
                            select new Event(product.Id, item.Nameof, JsonConvert.SerializeObject(item)));
            await eventRepository.AddAsync(events);

            product.ClearDomainEvent();

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
