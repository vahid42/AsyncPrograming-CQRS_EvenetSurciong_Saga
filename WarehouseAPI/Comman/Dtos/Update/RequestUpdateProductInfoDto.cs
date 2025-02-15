using System.Text.Json.Serialization;
using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Comman.Dtos.Update
{
    public class RequestUpdateProductInfoDto
    {
        [JsonIgnore]
        public string? UniversalProductCode { get; set; }
        public string? ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public string? Description { get; set; }

        public CompanyInformationDto? CompanyInformation { get; set; }

    }
}
