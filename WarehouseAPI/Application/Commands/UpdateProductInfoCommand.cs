using WarehouseAPI.Comman.Dtos.Create;
using WarehouseAPI.Comman.Dtos.Update;

namespace WarehouseAPI.Application.Commands
{
    public class UpdateProductInfoCommand : ICommand<ResponseUpdateProductInfoDto>
    {
        public RequestUpdateProductInfoDto UpdateProductDto { get;}
        public UpdateProductInfoCommand(RequestUpdateProductInfoDto updateProductDto)
        {
            this.UpdateProductDto = updateProductDto;
        }

    }
}
