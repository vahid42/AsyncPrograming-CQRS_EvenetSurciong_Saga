using Microsoft.AspNetCore.Mvc;
using WarehouseAPIv2.Application.Commands;
using WarehouseAPIv2.Application.Commands.CommandHandlers;
using WarehouseAPIv2.Comman.Dtos;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] RequestProductDto productDto, [FromServices] ICommandHandler<CreateProductCommand, ResposeProductDto> commandHandler)
        {
            var result = await commandHandler.HandleAsync(new CreateProductCommand(productDto));
            return Ok(result);
        }
    }
}