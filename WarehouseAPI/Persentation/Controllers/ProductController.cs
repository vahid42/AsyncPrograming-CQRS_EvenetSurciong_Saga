using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Application.Commands;
using WarehouseAPI.Application.Commands.CommandHandlers;
using WarehouseAPI.Comman.DtoInput;
using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {


        //[HttpGet("GetProducts")]
        //public async Task<IActionResult> GetProducts([FromBody] RequestGetProductDto dto)
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateOrders([FromBody] CreateProductInDto createProductInDto, [FromServices] ICommandHandler<CreateProductCommand, ProductDto> commandHandler)
        //{

        //    var dd = await commandHandler.HandleAsync(new CreateProductCommand(createProductInDto));
        //    return Ok(dd);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateOrders([FromBody] CreateProductInDto createProductInDto, [FromServices] ICommandHandler<CreateProductCommand, ProductDto> commandHandler)
        //{

        //    var dd = await commandHandler.HandleAsync(new CreateProductCommand(createProductInDto));
        //    return Ok(dd);
        //}


    }
}