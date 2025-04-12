namespace WarehouseAPIv2.Domain.Events
{
    public class ProductActivatedEvent : DomainEvent
    {

        public ProductActivatedEvent(Guid productId, bool isActive,string nameof)
        {
            ProductId = productId;
            IsActive = isActive;
            Nameof = nameof;
        }
        public Guid ProductId { get; }

        public bool IsActive { get; }
    }


}
