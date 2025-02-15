using AutoMapper;
using WarehouseAPI.Comman.Dtos.Create;
using WarehouseAPI.Comman.Dtos.Update;
using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestCreateProductDto, ResponseCreateProductDto>();
        }
    }
}
