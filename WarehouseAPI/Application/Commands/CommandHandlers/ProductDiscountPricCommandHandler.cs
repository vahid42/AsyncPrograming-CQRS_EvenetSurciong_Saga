using WarehouseAPI.Comman.Dtos;
using WarehouseAPI.Comman.Dtos.Create;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public class ProductDiscountPricCommandHandler : ICommandHandler<ProductDiscountPricCommand, ResponseProductDiscountPriceDto>
    {
        private readonly IWarehouseRepository<Product> repository;

        public ProductDiscountPricCommandHandler(IWarehouseRepository<Product> repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseProductDiscountPriceDto> HandleAsync(ProductDiscountPricCommand command)
        {
            var code = command.RequestProductDiscountPriceDto.UniversalProductCode;
            var product = await repository.GetByCodeAsync(code);
            if (product == null)
                if (product == null)
                    throw new KeyNotFoundException($"Product with UniversalProductCode {code} not found.");

            product.AddProductDiscountPrice(command.RequestProductDiscountPriceDto.StartDiscount, command.RequestProductDiscountPriceDto.EndDiscount, command.RequestProductDiscountPriceDto.DiscountPercentage);

            var result = await repository.UpdateAsync(product);
            var productDiscountPriceDto = new ResponseProductDiscountPriceDto();
            if (result != null)
            {
                productDiscountPriceDto.FinalPriceWithDiscount = result.ProductDiscountPrices.FirstOrDefault(c => c.IsActive).FinalPriceWithDiscount;
                productDiscountPriceDto.OriginalPrice = product.ProductPrices.FirstOrDefault(c => c.IsActive).FinalPrice;

            }

            return productDiscountPriceDto;



        }
    }
}
