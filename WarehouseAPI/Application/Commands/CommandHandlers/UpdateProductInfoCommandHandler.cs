using AutoMapper;
using WarehouseAPI.Comman.Dtos.Create;
using WarehouseAPI.Comman.Dtos.Update;
using WarehouseAPI.Domain.DomainService;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public class UpdateProductInfoCommandHandler : ICommandHandler<UpdateProductInfoCommand, ResponseUpdateInfoProductDto>
    {
        private readonly IWarehouseRepository<Product> repository;
        private readonly IProductDomainService domainService;
        private readonly IMapper mapper;

        public UpdateProductInfoCommandHandler(IWarehouseRepository<Product> repository, IProductDomainService domainService, IMapper mapper)
        {
            this.repository = repository;
            this.domainService = domainService;
            this.mapper = mapper;
        }
        public async Task<ResponseUpdateInfoProductDto> HandleAsync(UpdateProductInfoCommand command)
        {

            var product = await repository.GetByCodeAsync(command.UpdateProductDto.UniversalProductCode);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {command.UpdateProductDto.UniversalProductCode} not found.");

            if (command.UpdateProductDto.CompanyInformation == null)
            {
                product.UpdateAsync(command.UpdateProductDto.ProductName, command.UpdateProductDto.ProductType, command.UpdateProductDto.Description, product.CompanyInformation);

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
                product.UpdateAsync(command.UpdateProductDto.ProductName, command.UpdateProductDto.ProductType, command.UpdateProductDto.Description, companyInformation);

            }

            var result = await repository.UpdateAsync(product);


            return new ResponseUpdateInfoProductDto()
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
