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
            var result = await queryHandler.HandleAsync(new GetProductQuery(productDto));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] RequestCreateProductDto productDto, [FromServices] ICommandHandler<CreateProductCommand, ResponseCreateProductDto> commandHandler)
        {
            var result = await commandHandler.HandleAsync(new CreateProductCommand(productDto));
            return Ok(result);
        }
      
        [HttpPatch("UpdateProductInfo/{UniversalProductCode}")]
        public async Task<IActionResult> UpdateProductInfo( string UniversalProductCode, [FromBody] RequestUpdateProductInfoDto productDto, [FromServices] ICommandHandler<UpdateProductInfoCommand, ResponseUpdateProductInfoDto> commandHandler)
        {
            productDto.UniversalProductCode = UniversalProductCode;
            var result = await commandHandler.HandleAsync(new UpdateProductInfoCommand(productDto));
            return Ok(result);
        }

        [HttpPatch("UpdateProductPrice/{UniversalProductCode}")]
        public async Task<IActionResult> UpdateProductPrice(string UniversalProductCode, [FromBody] RequestUpdateProductPriceDto productDto, [FromServices] ICommandHandler<UpdateProductPriceCommand, ResponseUpdateProductPriceDto> commandHandler)
        {
            productDto.UniversalProductCode = UniversalProductCode;
            var result = await commandHandler.HandleAsync(new UpdateProductPriceCommand(productDto));
            return Ok(result);
        }

        [HttpPost("AddProductDiscountPrice/{UniversalProductCode}")]
        public async Task<IActionResult> AddProductDiscountPrice(string UniversalProductCode, [FromBody] RequestProductDiscountPriceDto productDto, [FromServices] ICommandHandler<ProductDiscountPricCommand, ResponseProductDiscountPriceDto> commandHandler)
        {
            productDto.UniversalProductCode = UniversalProductCode;
            var result = await commandHandler.HandleAsync(new ProductDiscountPricCommand(productDto));
            return Ok(result);
        }

 



    }
}