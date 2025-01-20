using AutoMapper;
using WarehouseAPI.Comman.Dtos;
using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestCreateOrUpdateProductDto, ResponseCreateOrUpdateProductDto>();
        }
    }
}
