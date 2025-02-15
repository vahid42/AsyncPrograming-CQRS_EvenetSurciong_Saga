using WarehouseAPI.Comman.Dtos.Create;

namespace WarehouseAPI.Comman.Dtos.Update
{
    public class ResponseUpdateInfoProductDto : RequestUpdateProductInfoDto
    {
        public Guid Id { get; set; }
    }
}
