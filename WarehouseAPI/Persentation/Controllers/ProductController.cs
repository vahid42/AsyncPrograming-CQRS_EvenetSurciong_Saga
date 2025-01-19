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
        public async Task<IActionResult> CreateOrders([FromBody] CreateProductDto productDto, [FromServices] ICommandHandler<CreateProductCommand, CreateProductDto> commandHandler )
        {
            var dd = await commandHandler.HandleAsync(new CreateProductCommand(productDto));
            return Ok(dd);
        }



    }
}