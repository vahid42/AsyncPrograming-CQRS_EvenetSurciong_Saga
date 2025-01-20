using AutoMapper;
using WarehouseAPI.Comman.Dtos;
using WarehouseAPI.Domain.DomainService;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ResponseCreateOrUpdateProductDto>
    {
        private readonly IWarehouseRepository<Product> repository;
        private readonly IProductDomainService domainService;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IWarehouseRepository<Product> repository, IProductDomainService domainService, IMapper mapper)
        {
            this.repository = repository;
            this.domainService = domainService;
            this.mapper = mapper;
        }
        public async Task<ResponseCreateOrUpdateProductDto> HandleAsync(UpdateProductCommand command)
        {

            var product = await repository.GetByCodeAsync(command.UpdateProductDto.UniversalProductCode);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {command.UpdateProductDto.UniversalProductCode} not found.");

            var companyInformation = new CompanyInformation(
                command.UpdateProductDto.CompanyInformation.CompanyName,
                command.UpdateProductDto.CompanyInformation.CompanyAddress,
                command.UpdateProductDto.CompanyInformation.CompanyPhone,
                command.UpdateProductDto.CompanyInformation.CompanyEmail,
                command.UpdateProductDto.CompanyInformation.MadeCountry
            );


            product.UpdateAsync(command.UpdateProductDto.ProductName, command.UpdateProductDto.ProductType, command.UpdateProductDto.Description, companyInformation);
            product.UpdateProductPrice(command.UpdateProductDto.PurchasePrice, command.UpdateProductDto.PercentageProfitPrice, command.UpdateProductDto.Quantity);
            await repository.UpdateAsync(product);
            var response = mapper.Map<ResponseCreateOrUpdateProductDto>(command.UpdateProductDto);
            response.Id = product.Id;


            return response;
        }
    }
}
