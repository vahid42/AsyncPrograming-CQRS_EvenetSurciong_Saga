using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Comman.Dtos
{
    public class RequestGetProductDto
    {
        public string? ProductName { get; set; }
        public string? UniversalProductCode { get; set; }
    }
}
