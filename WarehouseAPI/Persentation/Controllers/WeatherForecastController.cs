using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Commands;
using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            ICommand<Product> dd = new CreateProductCommand("", ProductType.Technologies, 10, 0, 550, "00");
        }
    }
}