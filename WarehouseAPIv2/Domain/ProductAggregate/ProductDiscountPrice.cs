using WarehouseAPIv2.Domain.Base;

namespace WarehouseAPIv2.Domain.ProductAggregate
{
    public class ProductDiscountPrice : ValueObject
    {
        public DateTime StartDiscount { get; private set; }
        public DateTime EndDiscount { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public decimal OriginalPrice { get; private set; }
        public decimal FinalPriceWithDiscount { get; private set; }


        public ProductDiscountPrice(decimal OriginalPrice, DateTime StartDiscount, DateTime EndDiscount, decimal DiscountPercentage)
        {

            if (StartDiscount >= EndDiscount)
                throw new ArgumentException("StartDiscount must be earlier than EndDiscount.");

            if (DiscountPercentage < 0 || DiscountPercentage > 100)
                throw new ArgumentOutOfRangeException(nameof(DiscountPercentage),"Discount percentage must be between 0 and 100.");

            if (OriginalPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(OriginalPrice),"Original price must be positive.");

            this.OriginalPrice = OriginalPrice;
            this.StartDiscount = StartDiscount;
            this.EndDiscount = EndDiscount;
            this.DiscountPercentage = DiscountPercentage;
            FinalPriceWithDiscount = CalculateFinalPrice();

        }

        private decimal CalculateFinalPrice()
        {
            if (DiscountPercentage == 0)
                return OriginalPrice;

            if (DiscountPercentage == 100)
                return 0;

            var discountAmount = OriginalPrice * (DiscountPercentage / 100m);
            return OriginalPrice - discountAmount;
        }
 

        public override bool Equals(object? obj)
        {
            if (obj is ProductDiscountPrice item)
                return StartDiscount == item.StartDiscount &&
                    EndDiscount == item.EndDiscount &&
                    DiscountPercentage == item.DiscountPercentage &&
                    OriginalPrice == item.OriginalPrice &&
                    FinalPriceWithDiscount == item.FinalPriceWithDiscount;

            return false;
        }

        public override int GetHashCode()
        {
            return (StartDiscount, EndDiscount, DiscountPercentage, OriginalPrice, FinalPriceWithDiscount).GetHashCode();
        }




    }
}
