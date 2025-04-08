namespace WarehouseAPIv2.Domain.Base
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreateDatetime { get; protected set; }

    }
}
