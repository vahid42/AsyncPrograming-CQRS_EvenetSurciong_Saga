using AutoMapper;
using WarehouseAPI.Comman.Dtos.Create;
using WarehouseAPI.Domain.DomainService;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ResponseCreateProductDto>
    {
        private readonly IWarehouseRepository<Product> repository;
        private readonly IProductDomainService domainService;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IWarehouseRepository<Product> repository, IProductDomainService domainService, IMapper mapper)
        {
            this.repository = repository;
            this.domainService = domainService;
            this.mapper = mapper;
        }
        public async Task<ResponseCreateProductDto> HandleAsync(CreateProductCommand command)
        {
            var companyInformation = new CompanyInformation(command.CreateProductDto.CompanyInformation.CompanyName, command.CreateProductDto.CompanyInformation.CompanyAddress,
                command.CreateProductDto.CompanyInformation.CompanyPhone, command.CreateProductDto.CompanyInformation.CompanyEmail, command.CreateProductDto.CompanyInformation.MadeCountry);

            var productFactory = new ProductFactory(domainService);
            var product = await productFactory.CreateProductAsync(command.CreateProductDto.ProductName, command.CreateProductDto.UniversalProductCode, command.CreateProductDto.ProductType, command.CreateProductDto.Description, companyInformation);
            product.AddProductPrice(command.CreateProductDto.PurchasePrice, command.CreateProductDto.PercentageProfitPrice, command.CreateProductDto.Quantity, domainService);
            product.ActiveProduct();

            var result = await repository.AddAsync(product);
            var response = mapper.Map<ResponseCreateProductDto>(command.CreateProductDto);
            response.Id = result.Id;
            return response;
        }
    }
}
