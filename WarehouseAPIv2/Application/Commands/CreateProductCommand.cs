
using WarehouseAPIv2.Comman.Dtos;

namespace WarehouseAPIv2.Application.Commands
{
    public class CreateProductCommand : ICommand<ResposeProductDto>
    {
        public RequestProductDto CreateProductDto { get;}
        public CreateProductCommand(RequestProductDto createProductDto)
        {
            CreateProductDto = createProductDto;
        }

    }
}
