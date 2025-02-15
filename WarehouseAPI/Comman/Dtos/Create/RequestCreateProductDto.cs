using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Comman.Dtos.Create
{
    public class RequestCreateProductDto
    {

        public string? ProductName { get; set; }
        public string? UniversalProductCode { get; set; }
        public ProductType ProductType { get; set; }
        public string? Description { get; set; }

        public CompanyInformationDto CompanyInformation { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PercentageProfitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
