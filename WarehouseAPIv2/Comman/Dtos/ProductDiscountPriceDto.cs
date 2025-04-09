namespace WarehouseAPIv2.Comman.Dtos
{
    public class ProductDiscountPriceDto
    {
        public DateTime StartDiscount { get; set; }
        public DateTime EndDiscount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal FinalPriceWithDiscount { get; set; }
    }
}
