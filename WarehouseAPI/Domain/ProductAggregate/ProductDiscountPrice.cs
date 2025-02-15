using WarehouseAPI.Domain.Base;

namespace WarehouseAPI.Domain.ProductAggregate
{
    public class ProductDiscountPrice : Entity
    {
        public DateTime StartDiscount { get; private set; }
        public DateTime EndDiscount { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public decimal OrginalPrice { get; private set; }
        public decimal FinalPriceWithDiscount { get; private set; }
        public DateTime CreateDatetime { get; protected set; }
        public bool IsActive { get; private set; }
        public Guid ProductId { get; private set; } // Foreign Key  
        public Product Product { get; private set; } // Navigation property  

        //for EF
        private ProductDiscountPrice() { }

        public ProductDiscountPrice(decimal OrginalPrice, DateTime StartDiscount, DateTime EndDiscount, decimal DiscountPercentage, Product product)
        {
            if (string.IsNullOrEmpty(product?.Id.ToString()))
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            if (StartDiscount >= EndDiscount)
                throw new ArgumentException("StartDiscount must be earlier than EndDiscount.");

            this.OrginalPrice = OrginalPrice;
            this.StartDiscount = StartDiscount;
            this.EndDiscount = EndDiscount;
            this.DiscountPercentage = DiscountPercentage;
            CreateDatetime = DateTime.Now;
            Product = product;
            ProductId = Product.Id;
            IsActive = true;
            FinalPriceWithDiscount = CalculateFinalPrice();

        }

        private decimal CalculateFinalPrice()
        {
            decimal discountAmount = DiscountPercentage / 100 * OrginalPrice;
            decimal finalPrice = OrginalPrice - discountAmount;
            return finalPrice;
        }


        public void Deactivate()
        {
            IsActive = false;
        }




    }
}
