using WarehouseAPI.Domain.Base;

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
        public ProductType ProductType { get; protected set; }
        public CompanyInformation CompanyInformation { get; protected set; }
        public bool IsActive { get; protected set; }
        public string? Description { get; protected set; }
        public DateTime CreateDatetime { get; private set; }
        public IReadOnlyCollection<ProductPrice> ProductPrices => productPrices.AsReadOnly();//add an agent will cause an error
        public IReadOnlyCollection<ProductDiscountPrice> ProductDiscountPrices => productDiscountPrices.AsReadOnly();


        public Product(string ProductName, ProductType ProductType, string? Description, CompanyInformation companyInformation)
        {
            if (ProductName != null || ProductName != string.Empty)
                throw new ArgumentOutOfRangeException("The Product name must not be empty.");

            Id = Guid.NewGuid();
            CreateDatetime = DateTime.Now;
            IsActive = true;
            productDiscountPrices = new List<ProductDiscountPrice>();
            productPrices = new List<ProductPrice>();
            this.ProductName = ProductName;
            this.ProductType = ProductType;
            this.Description = Description;
            CompanyInformation = companyInformation;
        }

        public void AddProductPrice(decimal  PurchasePrice, decimal  PercentageProfitPrice, int Quantity)
        {
            var productPrice = new ProductPrice(PurchasePrice, PercentageProfitPrice, Quantity, this);
            productPrices.Add(productPrice);
        }

        public void AddProductDiscountPrice(DateTime StartDiscount, DateTime EndDiscount, decimal  DiscountPercentage)
        {
            decimal  orginalPrice = productPrices.FirstOrDefault(c => c.IsActive)?.FinalPrice ?? 0;
            var productDiscountPrice = new ProductDiscountPrice(orginalPrice, StartDiscount, EndDiscount, DiscountPercentage, this);
            productDiscountPrices.Add(productDiscountPrice);
        }

        //public void Update(string ProductName, ProductType ProductType, string? Description, int Quantity)
        //{
        //    if (ProductName != null || ProductName != string.Empty)
        //        throw new ArgumentOutOfRangeException("The Product name must not be empty.");
        //    this.ProductName = ProductName;
        //    this.ProductType = ProductType;
        //    this.Description = Description;
        //    this.Quantity = Quantity;
        //}
        //public void UpdatePrice(decimal  Price)
        //{
        //    if (Price < 1)
        //        throw new ArgumentOutOfRangeException("The Product price should not be zero.");
        //    if (!this.IsActive)
        //        throw new ArgumentOutOfRangeException("The Product is inactive.");
        //    if (this.Quantity < 1)
        //        throw new ArgumentOutOfRangeException("The Product quantity is less than one.");

        //    this.Price = Price;

        //}
        //public void UpdateDiscountedPrice(decimal  DiscountedPrice)
        //{
        //    if (Price < 1)
        //        throw new ArgumentOutOfRangeException("The Product price should not be zero.");
        //    if (!this.IsActive)
        //        throw new ArgumentOutOfRangeException("The Product is inactive.");
        //    if (this.Quantity < 1)
        //        throw new ArgumentOutOfRangeException("The Product quantity is less than one.");

        //    this.DiscountedPrice = DiscountedPrice;
        //}
        //public void IsActiveProduct()
        //{
        //    if (this.Quantity < 1)
        //        throw new ArgumentOutOfRangeException("The Product quantity is less than one.");

        //    this.IsActive = true;
        //}
        //public void DeActiveProduct()
        //{
        //    this.IsActive = false;
        //}
    }
}
