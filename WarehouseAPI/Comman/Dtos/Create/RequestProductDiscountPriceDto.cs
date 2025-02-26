using System.Text.Json.Serialization;

namespace WarehouseAPI.Comman.Dtos.Create
{
    public class RequestProductDiscountPriceDto
    {
        [JsonIgnore]
        public string? UniversalProductCode { get; set; }
        public required DateTime StartDiscount { get;  set; }
        public required DateTime EndDiscount { get;  set; }
        public required decimal DiscountPercentage { get;  set; }
    }
}
