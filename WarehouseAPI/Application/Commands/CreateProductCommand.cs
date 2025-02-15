using WarehouseAPI.Comman.Dtos.Create;

namespace WarehouseAPI.Application.Commands
{
    public class CreateProductCommand : ICommand<ResponseCreateProductDto>
    {
        public RequestCreateProductDto CreateProductDto { get;}
        public CreateProductCommand(RequestCreateProductDto createProductDto)
        {
            CreateProductDto = createProductDto;
        }

    }
}
