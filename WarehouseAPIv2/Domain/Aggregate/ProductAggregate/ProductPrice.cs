using WarehouseAPIv2.Domain.Base;

namespace WarehouseAPIv2.Domain.Aggregate.ProductAggregate
{
    public class ProductPrice : ValueObject
    {
        public decimal PurchasePrice { get; private set; }
        public decimal PercentageProfitPrice { get; private set; }
        public decimal FinalPrice { get; private set; }
        public int Quantity { get; protected set; }
        public int RemainingQuantity { get; protected set; }


        public ProductPrice(decimal PurchasePrice, decimal PercentageProfitPrice, int Quantity)
        {
            if (PurchasePrice < 0)
                throw new ArgumentOutOfRangeException(nameof(PurchasePrice), "Purchase price cannot be negative.");

            if (PercentageProfitPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(PercentageProfitPrice), "Percentage profit price cannot be negative.");

            this.PurchasePrice = PurchasePrice;
            this.PercentageProfitPrice = PercentageProfitPrice;
            this.Quantity = Quantity;
            RemainingQuantity = Quantity;
            FinalPrice = PurchasePrice * PercentageProfitPrice / 100 + PurchasePrice;

        }

        public override bool Equals(object? obj)
        {
            if (obj is ProductPrice item)
                return PurchasePrice == item.PurchasePrice &&
                    PercentageProfitPrice == item.PercentageProfitPrice &&
                    FinalPrice == item.FinalPrice &&
                    Quantity == item.Quantity &&
                    RemainingQuantity == item.RemainingQuantity;

            return false;
        }

        public override int GetHashCode()
        {
            return (PurchasePrice, PercentageProfitPrice, FinalPrice, Quantity, RemainingQuantity).GetHashCode();
        }

    }
}
