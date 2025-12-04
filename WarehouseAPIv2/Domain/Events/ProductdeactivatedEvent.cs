namespace WarehouseAPIv2.Domain.Events
{
    public class ProductdeactivatedEvent : DomainEvent
    {

        public ProductdeactivatedEvent(Guid productId, bool isActive, string nameof)
        {
            ProductId = productId;
            IsActive = isActive;
            Nameof = nameof;
        }
        public Guid ProductId { get; }

        public bool IsActive { get; }
    }


}
