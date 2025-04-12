namespace WarehouseAPIv2.Domain.Events
{
    public class ProductPriceUpdatedEvent : DomainEvent
    {
        public ProductPriceUpdatedEvent(Guid productId, decimal newPurchasePrice, decimal newPercentageProfitPrice, int newQuantity, string nameof)
        {
            ProductId = productId;
            NewPurchasePrice = newPurchasePrice;
            NewPercentageProfitPrice = newPercentageProfitPrice;
            NewQuantity = newQuantity;
            Nameof = nameof;
        }

        public Guid ProductId { get; }  
        public decimal NewPurchasePrice { get; }  
        public decimal NewPercentageProfitPrice { get; }  
        public int NewQuantity { get; } 
     }
}
