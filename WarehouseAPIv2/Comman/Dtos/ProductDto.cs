using WarehouseAPIv2.Domain.ProductAggregate;

namespace WarehouseAPIv2.Comman.Dtos
{
    public class ProductDto
    {
        public string? ProductName { get; set; }
        public string? UniversalProductCode { get; set; }
        public ProductType ProductType { get; set; }
        public CompanyInformationDto? CompanyInformation { get; set; }
        public string? Description { get; set; }
        public ProductPriceDto? ProductPrice { get; set; }
        public ProductDiscountPriceDto? ProductDiscountPrice { get; set; }
    }
}
