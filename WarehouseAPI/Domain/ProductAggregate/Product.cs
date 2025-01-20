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
        private readonly IProductDomainService domainService;

        public string? ProductName { get; protected set; }
        public string? UniversalProductCode { get; protected set; }
        public ProductType ProductType { get; protected set; }
        public CompanyInformation CompanyInformation { get; protected set; }
        public bool IsActive { get; protected set; }
        public string? Description { get; protected set; }
        public DateTime CreateDatetime { get; private set; }
        public IReadOnlyCollection<ProductPrice> ProductPrices => productPrices.AsReadOnly();//add an agent will cause an error
        public IReadOnlyCollection<ProductDiscountPrice> ProductDiscountPrices => productDiscountPrices.AsReadOnly();

        private Product() { }
       
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

            return new Product(productName, universalProductCode, productType, description, companyInformation);
        }

        public void AddProductPrice(decimal PurchasePrice, decimal PercentageProfitPrice, int Quantity)
        {
            var productPrice = new ProductPrice(PurchasePrice, PercentageProfitPrice, Quantity, this);
            productPrices.Add(productPrice);
        }

        public void AddProductDiscountPrice(DateTime StartDiscount, DateTime EndDiscount, decimal DiscountPercentage)
        {
            decimal orginalPrice = productPrices.FirstOrDefault(c => c.IsActive)?.FinalPrice ?? 0;
            var productDiscountPrice = new ProductDiscountPrice(orginalPrice, StartDiscount, EndDiscount, DiscountPercentage, this);
            productDiscountPrices.Add(productDiscountPrice);
        }


        public void ActiveProduct()
        {
            this.IsActive = true;

        }


    }
}
