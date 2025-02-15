namespace WarehouseAPI.Comman.Dtos
{
    public class ProductPriceDto
    {
        public decimal PurchasePrice { get; set; }
        public decimal PercentageProfitPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public int RemainingQuantity { get; set; }

    }
}
