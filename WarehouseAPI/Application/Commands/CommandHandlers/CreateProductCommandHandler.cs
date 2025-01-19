using WarehouseAPI.Application.Commands;
using WarehouseAPI.Comman.Dtos;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductDto>
    {
        private readonly IWarehouseRepository<Product> repository;

        public CreateProductCommandHandler(IWarehouseRepository<Product> repository)
        {
            this.repository = repository;
        }
        public Task<CreateProductDto> HandleAsync(CreateProductCommand command)
        {
            var companyInformation = new CompanyInformation(command.CreateProductDto.CompanyInformation.CompanyName, command.CreateProductDto.CompanyInformation.CompanyAddress,
                command.CreateProductDto.CompanyInformation.CompanyPhone, command.CreateProductDto.CompanyInformation.CompanyEmail, command.CreateProductDto.CompanyInformation.MadeCountry);

            var product = new Product(command.CreateProductDto.ProductName,command.CreateProductDto.ProductType, command.CreateProductDto.Description, companyInformation);

            product.AddProductPrice(command.CreateProductDto.PurchasePrice, command.CreateProductDto.PercentageProfitPrice, command.CreateProductDto.Quantity);





        }
    }
}
