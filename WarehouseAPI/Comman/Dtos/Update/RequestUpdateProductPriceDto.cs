using System.Text.Json.Serialization;

namespace WarehouseAPI.Comman.Dtos.Update
{
    public class RequestUpdateProductPriceDto
    {
        [JsonIgnore]
        public string? UniversalProductCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PercentageProfitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
