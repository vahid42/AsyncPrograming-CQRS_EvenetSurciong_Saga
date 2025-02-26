using System.Runtime.CompilerServices;
using WarehouseAPI.Domain.Base;
using WarehouseAPI.Domain.DomainService;

namespace WarehouseAPI.Domain.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        /// <summary>
        /// Backing field for navigation property  
        /// </summary>
        private readonly List<ProductPrice> productPrices;
        private readonly List<ProductDiscountPrice> productDiscountPrices;

        public string? ProductName { get; protected set; }
        public string? UniversalProductCode { get; protected set; }
        public ProductType ProductType { get; protected set; }
        public CompanyInformation CompanyInformation { get; protected set; }
        public bool IsActive { get; protected set; }
        public string? Description { get; protected set; }
        public DateTime CreateDatetime { get; private set; }
        public IReadOnlyCollection<ProductPrice> ProductPrices => productPrices.AsReadOnly();//add an agent will cause an error
        public IReadOnlyCollection<ProductDiscountPrice> ProductDiscountPrices => productDiscountPrices.AsReadOnly();

        private Product()
        {
            productPrices = new List<ProductPrice>();
            productDiscountPrices = new List<ProductDiscountPrice>();
        }

        private Product(string ProductName, string UniversalProductCode, ProductType ProductType, string? Description, CompanyInformation companyInformation)
        {
            Id = Guid.NewGuid();
            CreateDatetime = DateTime.Now;
            productDiscountPrices = new List<ProductDiscountPrice>();
            productPrices = new List<ProductPrice>();
            this.ProductName = ProductName;
            this.UniversalProductCode = UniversalProductCode;
            this.ProductType = ProductType;
            this.Description = Description;
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
            bool exist = await domainService.ActiveCurrentProductPrice(UniversalProductCode);
            if (exist)
                throw new ArgumentException("The Product Price is already exists.");

            var productPrice = new ProductPrice(PurchasePrice, PercentageProfitPrice, Quantity, this);
            productPrices.Add(productPrice);
        }

        public void UpdateProductPrice(decimal newPurchasePrice, decimal newPercentageProfitPrice, int newQuantity)
        {
            var currentPrice = productPrices.FirstOrDefault(p => p.IsActive);
            if (currentPrice != null)
                currentPrice.Deactivate();

            var newProductPrice = new ProductPrice(newPurchasePrice, newPercentageProfitPrice, newQuantity, this);
            productPrices.Add(newProductPrice);
        }

 
        public void AddProductDiscountPrice(DateTime StartDiscount, DateTime EndDiscount, decimal DiscountPercentage)
        {

            var currentPrice = productPrices.FirstOrDefault(p => p.IsActive);
            if (currentPrice != null)
            {
                var discountcurrentPrice = productDiscountPrices.FirstOrDefault(p => p.IsActive);
                if (discountcurrentPrice != null)
                    discountcurrentPrice.Deactivate();

                var newProductDiscountPrice = new ProductDiscountPrice(currentPrice.FinalPrice, StartDiscount, EndDiscount, DiscountPercentage, this);
                productDiscountPrices.Add(newProductDiscountPrice);

            }
        }

        public void ActiveProduct()
        {
            this.IsActive = true;

        }


    }
}
