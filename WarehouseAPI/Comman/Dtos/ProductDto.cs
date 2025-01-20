using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Comman.Dtos
{
    public class ProductDto
    {
        public string? ProductName { get; set; }
        public string? GetByCodeAsync { get; set; }
        public ProductType ProductType { get; set; }
        public CompanyInformationDto CompanyInformation { get; protected set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDatetime { get; set; }
        public IList<ProductPriceDto> ProductPrices { get; set; }
        public IList<ProductDiscountPriceDto> ProductDiscountPrices { get; set; }
    }
}
