using System.Runtime.CompilerServices;
using WarehouseAPIv2.Domain.Base;
using WarehouseAPIv2.Domain.DomainService;

namespace WarehouseAPIv2.Domain.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {

        public string? ProductName { get; protected set; }
        public string? UniversalProductCode { get; protected set; }
        public ProductType ProductType { get; protected set; }
        public CompanyInformation CompanyInformation { get; protected set; }
        public bool IsActive { get; protected set; }
        public string? Description { get; protected set; }
        public ProductPrice? ProductPrice { get; protected set; }
        public ProductDiscountPrice? ProductDiscountPrice { get; protected set; }

        //EF
        private Product() {}

        private Product(string ProductName, string UniversalProductCode, ProductType ProductType, string? Description, CompanyInformation companyInformation)
        {
            Id = Guid.NewGuid();
            CreateDatetime = DateTime.Now;
            this.ProductName = ProductName;
            this.UniversalProductCode = UniversalProductCode;
            this.ProductType = ProductType;
            this.Description = Description;
            this.CreateDatetime = DateTime.Now;
            CompanyInformation = companyInformation;
        }


        public static async Task<Product> CreateAsync(string productName, string universalProductCode, ProductType productType, string? description, CompanyInformation companyInformation, IProductDomainService domainService)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentOutOfRangeException("The Product name must not be empty.");

            if (string.IsNullOrWhiteSpace(universalProductCode))
                throw new ArgumentOutOfRangeException("The Universal Product Code must not be empty.");

            bool codeExist = await domainService.DuplicateCodeCheck(universalProductCode);
            if (codeExist)
                throw new ArgumentException("The Universal Product Code already exists.");

            if (productType == ProductType.None)
                throw new ArgumentOutOfRangeException("The Product ProductType must not be None.");

            return new Product(productName, universalProductCode, productType, description, companyInformation);
        }

        public void UpdateInfo(string productName, ProductType productType, string? description, CompanyInformation companyInformation)
        {
            if (!string.IsNullOrWhiteSpace(productName))
                this.ProductName = productName;
            if (!string.IsNullOrWhiteSpace(description))
                this.Description = description;
            if (companyInformation != null)
                this.CompanyInformation = companyInformation;
            if (productType != ProductType.None)
                this.ProductType = productType;
        }

        public async void AddProductPriceAsync(decimal PurchasePrice, decimal PercentageProfitPrice, int Quantity, IProductDomainService domainService)
        {
 

            ProductPrice = new ProductPrice(PurchasePrice, PercentageProfitPrice, Quantity);
        }

        public void UpdateProductPrice(decimal newPurchasePrice, decimal newPercentageProfitPrice, int newQuantity)
        {
            ProductPrice = new ProductPrice(newPurchasePrice, newPercentageProfitPrice, newQuantity);
        }


        public void AddProductDiscountPrice(DateTime StartDiscount, DateTime EndDiscount, decimal DiscountPercentage)
        {
            ProductDiscountPrice = new ProductDiscountPrice(ProductPrice.FinalPrice, StartDiscount, EndDiscount, DiscountPercentage);
        }

        public void ActiveProduct()
        {
            this.IsActive = true;

        }


    }
}
