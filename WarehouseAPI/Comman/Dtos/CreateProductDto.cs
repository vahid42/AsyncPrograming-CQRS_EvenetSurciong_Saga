﻿using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Comman.Dtos
{
    public class CreateProductDto
    {
        public string? ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public string? Description { get; protected set; }

        public CompanyInformationDto CompanyInformation { get; protected set; }
        public decimal PurchasePrice { get; set; }
        public decimal PercentageProfitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
