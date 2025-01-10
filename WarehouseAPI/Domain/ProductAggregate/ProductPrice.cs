using WarehouseAPI.Domain.Base;

namespace WarehouseAPI.Domain.ProductAggregate
{
    public class ProductPrice : Entity
    {
        public decimal PurchasePrice { get; private set; }
        public decimal PercentageProfitPrice { get; private set; }
        public decimal FinalPrice { get; private set; }
        public bool IsActive { get; private set; }
        public int Quantity { get; protected set; }
        public int RemainingQuantity { get; protected set; }
        public Guid ProductId { get; private set; } // Foreign Key  
        public Product Product { get; private set; } // Navigation property  

        //for EF
        private ProductPrice() { }
        public ProductPrice(decimal PurchasePrice, decimal PercentageProfitPrice, int Quantity, Product product)
        {
            if (PurchasePrice < 0)
                throw new ArgumentOutOfRangeException(nameof(PurchasePrice), "Purchase price cannot be negative.");

            if (PercentageProfitPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(PercentageProfitPrice), "Percentage profit price cannot be negative.");

            this.PurchasePrice = PurchasePrice;
            this.PercentageProfitPrice = PercentageProfitPrice;
            this.Quantity = Quantity;
            IsActive = true;
            Product = product;
            ProductId = Product.Id;
            FinalPrice = PurchasePrice * PercentageProfitPrice;

        }

        public void ReduceQuantity(int amount)
        {
            if (RemainingQuantity >= amount)
                RemainingQuantity -= amount;
            else
                throw new InvalidOperationException("Not enough quantity available.");
        }
        public void Deactivate()
        {
            IsActive = false;
        }

    }
}
