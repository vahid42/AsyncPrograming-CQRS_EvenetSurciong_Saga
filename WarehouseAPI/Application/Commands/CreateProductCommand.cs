using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Commands
{
    public class CreateProductCommand: ICommand<Product>
    {
        public CreateProductCommand(string? productName, ProductType productType, decimal  price, decimal  discountedPrice, int quantity, string? description)
        {
            ProductName = productName;
            ProductType = productType;
            Price = price;
            DiscountedPrice = discountedPrice;
            Quantity = quantity;
            Description = description;
        }

        public string? ProductName { get;   }
        public ProductType ProductType { get; }
        public decimal  Price { get;  }
        public decimal  DiscountedPrice { get;}
        public int Quantity { get; }
        public string? Description { get; }

    }
}
