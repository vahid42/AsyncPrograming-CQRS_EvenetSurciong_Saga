namespace WarehouseAPIv2.Domain.Events
{
    public class ProductDiscountPriceUpdatedEvent: DomainEvent
    {
        public ProductDiscountPriceUpdatedEvent(Guid productId, decimal basePrice, DateTime startDiscount, DateTime endDiscount, decimal discountPercentage, string nameof)
        {
            ProductId = productId;
            BasePrice = basePrice;
            StartDiscount = startDiscount;
            EndDiscount = endDiscount;
            DiscountPercentage = discountPercentage;
            Nameof = nameof;
        }

        public Guid ProductId { get; }
        public decimal BasePrice { get; }
        public DateTime StartDiscount { get; }
        public DateTime EndDiscount { get; }
        public decimal DiscountPercentage { get; }
    }
}
