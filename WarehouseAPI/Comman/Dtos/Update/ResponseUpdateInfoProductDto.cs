using WarehouseAPI.Comman.Dtos.Create;

namespace WarehouseAPI.Comman.Dtos.Update
{
    public class ResponseUpdateProductInfoDto : RequestUpdateProductInfoDto
    {
        public Guid Id { get; set; }
    }
}
