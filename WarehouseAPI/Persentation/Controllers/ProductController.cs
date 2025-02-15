using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Application.Commands;
using WarehouseAPI.Application.Commands.CommandHandlers;
using WarehouseAPI.Application.Queries;
using WarehouseAPI.Application.Queries.QueryHandlers;
using WarehouseAPI.Comman.Dtos.Create;
using WarehouseAPI.Comman.Dtos.Get;
using WarehouseAPI.Comman.Dtos.Update;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] RequestGetProductDto productDto, [FromServices] IQueryHandler<GetProductQuery, ResponseGetProduct> queryHandler)
        {
            var dd = await queryHandler.HandleAsync(new GetProductQuery(productDto));
            return Ok(dd);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] RequestCreateProductDto productDto, [FromServices] ICommandHandler<CreateProductCommand, ResponseCreateProductDto> commandHandler)
        {
            var dd = await commandHandler.HandleAsync(new CreateProductCommand(productDto));
            return Ok(dd);
        }
        [HttpPatch("UpdateProductInfo/{Code}")]
        public async Task<IActionResult> UpdateProductInfo( string Code ,[FromBody] RequestUpdateProductInfoDto productDto, [FromServices] ICommandHandler<UpdateProductInfoCommand, ResponseUpdateInfoProductDto> commandHandler)
        {
            productDto.UniversalProductCode = Code;
            var dd = await commandHandler.HandleAsync(new UpdateProductInfoCommand(productDto));
            return Ok(dd);
        }




    }
}