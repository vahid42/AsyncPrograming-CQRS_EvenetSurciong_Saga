namespace WarehouseAPI.Comman.Dtos
{
    public class ProductDiscountPriceDto
    {
        public DateTime StartDiscount { get; set; }
        public DateTime EndDiscount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal OrginalPrice { get; set; }
        public decimal FinalPriceWithDiscount { get; set; }
        public bool IsActive { get; set; }
    }
}
