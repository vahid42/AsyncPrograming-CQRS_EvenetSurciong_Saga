using WarehouseAPI.Comman.Dtos.Update;

namespace WarehouseAPI.Application.Commands
{
    public class UpdateProductPriceCommand : ICommand<ResponseUpdateProductPriceDto>
    {
        public RequestUpdateProductPriceDto UpdateProductDto { get; }
        public UpdateProductPriceCommand(RequestUpdateProductPriceDto updateProductDto)
        {
            this.UpdateProductDto = updateProductDto;
        }

    }
}
