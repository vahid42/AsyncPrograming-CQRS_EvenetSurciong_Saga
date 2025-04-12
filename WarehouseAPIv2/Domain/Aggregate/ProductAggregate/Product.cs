using System.Runtime.CompilerServices;
using WarehouseAPIv2.Domain.Aggregate.EventAggregate;
using WarehouseAPIv2.Domain.Base;
using WarehouseAPIv2.Domain.DomainService;
using WarehouseAPIv2.Domain.Events;

namespace WarehouseAPIv2.Domain.Aggregate.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        private readonly List<DomainEvent> domainEvents = new();

        public string? ProductName { get; protected set; }
        public string? UniversalProductCode { get; protected set; }
        public ProductType ProductType { get; protected set; }
        public CompanyInformation CompanyInformation { get; protected set; }
        public bool IsActive { get; protected set; }
        public string? Description { get; protected set; }
        public ProductPrice? ProductPrice { get; protected set; }
        public ProductDiscountPrice? ProductDiscountPrice { get; protected set; }
        public IReadOnlyCollection<DomainEvent> DomainEvents => domainEvents.AsReadOnly();


        //EF
        private Product() { }

        public static async Task<Product> CreateAsync(string productName, string universalProductCode, ProductType productType, string? description, CompanyInformation companyInformation, IProductDomainService domainService)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentNullException("The Product name must not be empty.");

            if (string.IsNullOrWhiteSpace(universalProductCode))
                throw new ArgumentNullException("The Universal Product Code must not be empty.");

            bool codeExist = await domainService.DuplicateCodeCheck(universalProductCode);
            if (codeExist)
                throw new ArgumentException("The Universal Product Code already exists.");

            if (productType == ProductType.None)
                throw new ArgumentOutOfRangeException("The Product ProductType must not be None.");

            var product = new Product();
            var @event = new ProductCreatedEvent(
                                 Guid.NewGuid(),
                                 productName,
                                 universalProductCode,
                                 productType,
                                 description,
                                 DateTime.Now,
                                 companyInformation,
                                 nameof(Product)
                                 );
            product.Apply(@event);
            product.domainEvents.Add(@event);
            return product;
        }

        public void UpdateInfo(string productName, ProductType productType, string? description, CompanyInformation companyInformation)
        {
            if (!string.IsNullOrWhiteSpace(productName))
                ProductName = productName;
            if (!string.IsNullOrWhiteSpace(description))
                Description = description;
            if (companyInformation != null)
                CompanyInformation = companyInformation;
            if (productType != ProductType.None)
                ProductType = productType;

            var @event = new ProductInfoUpdatedEvent(
                                   Id,
                                   productName,
                                   productType,
                                   description,
                                   companyInformation,
                                   nameof(Product)
                                  );
            Apply(@event);
            domainEvents.Add(@event);
        }


        public void UpdateProductPrice(decimal newPurchasePrice, decimal newPercentageProfitPrice, int newQuantity)
        {
            var @event = new ProductPriceUpdatedEvent(
                        Id,
                        newPurchasePrice,
                        newPercentageProfitPrice,
                        newQuantity,
                        nameof(ProductPrice));

            Apply(@event);
            domainEvents.Add(@event);
        }


        public void UpdateProductDiscountPrice(DateTime startDiscount, DateTime endDiscount, decimal discountPercentage)
        {
            if (ProductPrice == null)
                throw new InvalidOperationException("Product price must be set first.");

            var @event = new ProductDiscountPriceUpdatedEvent(
                Id,
                ProductPrice.FinalPrice,
                startDiscount,
                endDiscount,
                discountPercentage,
                nameof(ProductDiscountPrice)
               );

            Apply(@event);
            domainEvents.Add(@event);
        }

        public void ActiveProduct()
        {
            var @event = new ProductActivatedEvent(Id,true, nameof(Product));
            Apply(@event);
            domainEvents.Add(@event);

        }


        private void Apply(DomainEvent @event)
        {
            switch (@event)
            {
                case ProductCreatedEvent e:
                    Id = e.ProductId;
                    ProductName = e.ProductName;
                    UniversalProductCode = e.UniversalProductCode;
                    ProductType = e.ProductType;
                    Description = e.Description;
                    CompanyInformation = e.CompanyInformation;
                    break;

                case ProductInfoUpdatedEvent e:
                    ProductName = e.ProductName;
                    Description = e.Description;
                    CompanyInformation = e.CompanyInformation;
                    ProductType = e.ProductType;
                    break;

                case ProductPriceUpdatedEvent e:
                    ProductPrice = new ProductPrice(
                        e.NewPurchasePrice,
                        e.NewPercentageProfitPrice,
                        e.NewQuantity);
                    break;

                case ProductDiscountPriceUpdatedEvent e:
                    ProductDiscountPrice = new ProductDiscountPrice(
                        e.BasePrice,
                        e.StartDiscount,
                        e.EndDiscount,
                        e.DiscountPercentage);
                    break;

                case ProductActivatedEvent e:
                    IsActive = e.IsActive;
                    break;
            }
        }

    }
}
