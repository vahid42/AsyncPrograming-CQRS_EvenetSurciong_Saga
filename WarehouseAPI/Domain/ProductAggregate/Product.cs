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
        public string? ProductCode { get; protected set; }
        public ProductType ProductType { get; protected set; }
        public CompanyInformation CompanyInformation { get; protected set; }
        public bool IsActive { get; protected set; }
        public string? Description { get; protected set; }
        public DateTime CreateDatetime { get; private set; }
        public IReadOnlyCollection<ProductPrice> ProductPrices => productPrices.AsReadOnly();//add an agent will cause an error
        public IReadOnlyCollection<ProductDiscountPrice> ProductDiscountPrices => productDiscountPrices.AsReadOnly();
        private Product() { }
        public Product(string ProductName, ProductType ProductType, string? Description, CompanyInformation companyInformation, IProductDomainService domainService)
        {
            if (ProductName == null || ProductName == string.Empty)
                throw new ArgumentOutOfRangeException("The Product name must not be empty.");


            Id = Guid.NewGuid();
            CreateDatetime = DateTime.Now;
            productDiscountPrices = new List<ProductDiscountPrice>();
            productPrices = new List<ProductPrice>();
            this.ProductName = ProductName;
            this.ProductType = ProductType;
            this.Description = Description;
            CompanyInformation = companyInformation;
            this.domainService = domainService;

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


        private string generateCode()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 650);
            return "P" + number.ToString();
        }

        public async void ActiveProduct()
        {
            this.IsActive = true;
            var _code = generateCode();
            while (true)
            {
                var codeexist = await domainService.DuplicateCodeCheck(_code);
                if (!codeexist)
                {
                    ProductCode = _code;
                    break; 
                }
            }

        }


    }
}
