using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Application.Commands;
using WarehouseAPI.Application.Commands.CommandHandlers;
using WarehouseAPI.Comman.Dtos;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] RequestCreateOrUpdateProductDto productDto, [FromServices] ICommandHandler<CreateProductCommand, ResponseCreateOrUpdateProductDto> commandHandler )
        {
            var dd = await commandHandler.HandleAsync(new CreateProductCommand(productDto));
            return Ok(dd);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] RequestCreateOrUpdateProductDto productDto, [FromServices] ICommandHandler<UpdateProductCommand, ResponseCreateOrUpdateProductDto> commandHandler)
        {
            var dd = await commandHandler.HandleAsync(new UpdateProductCommand(productDto));
            return Ok(dd);
        }




    }
}