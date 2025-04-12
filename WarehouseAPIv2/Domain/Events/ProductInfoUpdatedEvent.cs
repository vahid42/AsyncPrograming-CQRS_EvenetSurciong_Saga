using WarehouseAPIv2.Domain.Aggregate.ProductAggregate;

namespace WarehouseAPIv2.Domain.Events
{
    public class ProductInfoUpdatedEvent : DomainEvent
    {
        public ProductInfoUpdatedEvent(Guid productId, string productName, ProductType productType, string? description, CompanyInformation companyInformation, string nameof)
        {
            ProductId = productId;
            ProductName = productName;
            ProductType = productType;
            Description = description;
            CompanyInformation = companyInformation;
            Nameof = nameof;
        }

        public Guid ProductId { get; } 
        public string ProductName { get; } 
        public ProductType ProductType { get; }  
        public string? Description { get; } 
        public CompanyInformation CompanyInformation { get; } 
     }
}
