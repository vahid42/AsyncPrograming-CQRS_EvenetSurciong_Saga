using WarehouseAPI.Comman.Dtos;

namespace WarehouseAPI.Application.Commands
{
    public class CreateProductCommand : ICommand<CreateProductDto>
    {
        public CreateProductDto CreateProductDto { get;}
        public CreateProductCommand(CreateProductDto createProductDto)
        {
            CreateProductDto = createProductDto;
        }

    }
}
