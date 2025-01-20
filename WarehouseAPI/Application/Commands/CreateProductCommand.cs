using WarehouseAPI.Comman.Dtos;

namespace WarehouseAPI.Application.Commands
{
    public class CreateProductCommand : ICommand<ResponseCreateOrUpdateProductDto>
    {
        public RequestCreateOrUpdateProductDto CreateProductDto { get;}
        public CreateProductCommand(RequestCreateOrUpdateProductDto createProductDto)
        {
            CreateProductDto = createProductDto;
        }

    }
}
