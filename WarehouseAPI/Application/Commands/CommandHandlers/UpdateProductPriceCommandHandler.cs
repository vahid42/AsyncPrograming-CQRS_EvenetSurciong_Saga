using AutoMapper;
using WarehouseAPI.Comman.Dtos.Update;
using WarehouseAPI.Domain.DomainService;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public class UpdateProductPriceCommandHandler : ICommandHandler<UpdateProductPriceCommand, ResponseUpdateProductPriceDto>
    {
        private readonly IWarehouseRepository<Product> repository;

        public UpdateProductPriceCommandHandler(IWarehouseRepository<Product> repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseUpdateProductPriceDto> HandleAsync(UpdateProductPriceCommand command)
        {

            var product = await repository.GetByCodeAsync(command.UpdateProductDto.UniversalProductCode);
            if (product == null)
                throw new KeyNotFoundException($"Product with UniversalProductCode {command.UpdateProductDto.UniversalProductCode} not found.");

            product.UpdateProductPrice(command.UpdateProductDto.PurchasePrice, command.UpdateProductDto.PercentageProfitPrice, command.UpdateProductDto.Quantity);
            var result = await repository.UpdateAsync(product);
            return new ResponseUpdateProductPriceDto()
            {
                Id = result.Id,
                PercentageProfitPrice = command.UpdateProductDto.PercentageProfitPrice,
                PurchasePrice = command.UpdateProductDto.PurchasePrice,
                Quantity = command.UpdateProductDto.Quantity
            };
        }
    }
}
