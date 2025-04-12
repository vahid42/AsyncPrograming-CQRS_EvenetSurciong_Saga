using WarehouseAPIv2.Domain.Aggregate.ProductAggregate;

namespace WarehouseAPIv2.Domain.Events
{
    public class ProductCreatedEvent : DomainEvent
    {
        public ProductCreatedEvent(Guid productId, string productName, string universalProductCode, ProductType productType, string? description, DateTime createDatetime, CompanyInformation companyInformation, string nameof)
        {
            ProductId = productId;
            ProductName = productName;
            UniversalProductCode = universalProductCode;
            ProductType = productType;
            Description = description;
            CreateDatetime = createDatetime;
            CompanyInformation = companyInformation;
            Nameof = nameof;
        }

        public Guid ProductId { get; }
        public string ProductName { get; }
        public string UniversalProductCode { get; }
        public ProductType ProductType { get; }
        public string? Description { get; }
        public DateTime CreateDatetime { get; }
        public CompanyInformation CompanyInformation { get; }
    }

}
