using WarehouseAPI.Comman.Dtos.Get;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;

namespace WarehouseAPI.Application.Queries.QueryHandlers
{
    public class GetQueryHandler : IQueryHandler<GetProductQuery, ResponseGetProduct>
    {
        private readonly IWarehouseRepository<Product> productRepository;

        public GetQueryHandler(IWarehouseRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<ResponseGetProduct> HandleAsync(GetProductQuery query)
        {
            var response = new ResponseGetProduct();
            var result = productRepository.GetAll(c => c.UniversalProductCode == query.RequestGetProductDto.UniversalProductCode ||
            c.ProductName.Contains(query.RequestGetProductDto.ProductName)).FirstOrDefault();

            if (result != null)
            {
                response.Id = result.Id;
                response.UniversalProductCode = result.UniversalProductCode;
                response.ProductName = result.ProductName;
                response.ProductType = result.ProductType;
                response.Description = result.Description;
                response.CompanyInformation.CompanyName = result.CompanyInformation.CompanyName;
                response.CompanyInformation.CompanyPhone = result.CompanyInformation.CompanyPhone;
                response.CompanyInformation.CompanyAddress = result.CompanyInformation.CompanyAddress;
                response.CompanyInformation.CompanyEmail = result.CompanyInformation.CompanyEmail;
                response.CompanyInformation.MadeCountry = result.CompanyInformation.MadeCountry;
                var price = result.ProductPrices.FirstOrDefault(c => c.IsActive);
                if (price != null)
                {
                    response.FinalPrice = price.FinalPrice;
                    response.RemainingQuantity = price.RemainingQuantity;
                }
                var discount = result.ProductDiscountPrices.FirstOrDefault(c => c.IsActive);
                if (discount != null)
                {
                    response.IsDiscount = true;
                    response.FinalPriceWithDiscount = discount.FinalPriceWithDiscount;
                }

            }
            return response;
        }
    }
}
