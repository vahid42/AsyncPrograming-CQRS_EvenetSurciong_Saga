using WarehouseAPI.Comman.Dtos;

namespace WarehouseAPI.Application.Commands
{
    public class UpdateProductCommand  : ICommand<ResponseCreateOrUpdateProductDto>
    {
        public RequestCreateOrUpdateProductDto UpdateProductDto { get;}
        public UpdateProductCommand(RequestCreateOrUpdateProductDto updateProductDto)
        {
            this.UpdateProductDto = updateProductDto;
        }

    }
}
