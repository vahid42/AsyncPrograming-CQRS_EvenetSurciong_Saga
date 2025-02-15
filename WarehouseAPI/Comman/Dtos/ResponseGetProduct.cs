using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Comman.Dtos
{
    public class ResponseGetProduct
    {
        public ResponseGetProduct()
        {
            CompanyInformation = new CompanyInformationDto();
        }
        public Guid Id { get; set; }
        public string? ProductName { get; set; }
        public string? UniversalProductCode { get; set; }
        public ProductType ProductType { get; set; }
        public string? Description { get; set; }

        public CompanyInformationDto CompanyInformation { get; set; }
        public decimal FinalPrice { get; set; }
        public bool IsDiscount { get; set; }
        public decimal FinalPriceWithDiscount { get; set; }
        public int RemainingQuantity { get; set; }

    }
}
