using WarehouseAPI.Comman.Dtos.Create;

namespace WarehouseAPI.Application.Commands
{
    public class ProductDiscountPricCommand:ICommand<ResponseProductDiscountPriceDto>
    {
         public ProductDiscountPricCommand(RequestProductDiscountPriceDto requestProductDiscountPriceDto)
        {
            RequestProductDiscountPriceDto = requestProductDiscountPriceDto;
        }

        public RequestProductDiscountPriceDto RequestProductDiscountPriceDto { get; }
    }
}
