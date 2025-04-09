using WarehouseAPIv2.Domain.Base;

namespace WarehouseAPIv2.Domain.EventAggregate
{
    public class Event : Entity, IAggregateRoot
    {
        public Guid AggregateId { get; protected set; }
        public string EventType { get; protected set; }
        public string EventData { get; protected set; }


        private Event() { }

        public Event(Guid aggregateId, string eventType, string eventData)
        {
            if(aggregateId == Guid.Empty)
                throw new ArgumentNullException("The AggregateId must not be empty.");

            if (string.IsNullOrWhiteSpace(EventData))
                throw new ArgumentNullException("The EventData must not be empty.");

            if (string.IsNullOrWhiteSpace(EventType))
                throw new ArgumentNullException("The EventType must not be empty.");

            AggregateId = aggregateId;
            EventType = eventType;
            EventData = eventData;
            CreateDatetime = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
