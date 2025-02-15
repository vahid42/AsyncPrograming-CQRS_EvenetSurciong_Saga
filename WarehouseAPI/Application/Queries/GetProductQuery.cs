using WarehouseAPI.Comman.Dtos;

namespace WarehouseAPI.Application.Queries
{
    public class GetProductQuery : IQuery<ResponseGetProduct>
    {
        public RequestGetProductDto RequestGetProductDto { get; }
        public GetProductQuery(RequestGetProductDto requestGetProductDto)
        {
            this.RequestGetProductDto = requestGetProductDto;
        }
    }
}
