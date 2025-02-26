using AutoMapper;
using WarehouseAPI.Comman.Dtos.Create;
using WarehouseAPI.Comman.Dtos.Update;
using WarehouseAPI.Domain.DomainService;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public class UpdateProductInfoCommandHandler : ICommandHandler<UpdateProductInfoCommand, ResponseUpdateProductInfoDto>
    {
        private readonly IWarehouseRepository<Product> repository;

        public UpdateProductInfoCommandHandler(IWarehouseRepository<Product> repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseUpdateProductInfoDto> HandleAsync(UpdateProductInfoCommand command)
        {

            var product = await repository.GetByCodeAsync(command.UpdateProductDto.UniversalProductCode);
            if (product == null)
                throw new KeyNotFoundException($"Product with UniversalProductCode {command.UpdateProductDto.UniversalProductCode} not found.");

            if (command.UpdateProductDto.CompanyInformation == null)
            {
                product.UpdateInfo(command.UpdateProductDto.ProductName, command.UpdateProductDto.ProductType, command.UpdateProductDto.Description, product.CompanyInformation);

            }
            else
            {
                var companyInformation = new CompanyInformation(
                    command.UpdateProductDto.CompanyInformation.CompanyName,
                    command.UpdateProductDto.CompanyInformation.CompanyAddress,
                    command.UpdateProductDto.CompanyInformation.CompanyPhone,
                    command.UpdateProductDto.CompanyInformation.CompanyEmail,
                    command.UpdateProductDto.CompanyInformation.MadeCountry
                );
                product.UpdateInfo(command.UpdateProductDto.ProductName, command.UpdateProductDto.ProductType, command.UpdateProductDto.Description, companyInformation);

            }

            var result = await repository.UpdateAsync(product);


            return new ResponseUpdateProductInfoDto()
            {
                Id = result.Id,
                ProductType = result.ProductType,
                CompanyInformation = new Comman.Dtos.CompanyInformationDto()
                {
                    CompanyAddress = result.CompanyInformation.CompanyAddress,
                    CompanyEmail = result.CompanyInformation.CompanyEmail,
                    CompanyName = result.CompanyInformation.CompanyName,
                    CompanyPhone = result.CompanyInformation.CompanyPhone,
                    MadeCountry = result.CompanyInformation.MadeCountry
                },
                Description = result.Description,
                ProductName = result.ProductName
            };
        }
    }
}
