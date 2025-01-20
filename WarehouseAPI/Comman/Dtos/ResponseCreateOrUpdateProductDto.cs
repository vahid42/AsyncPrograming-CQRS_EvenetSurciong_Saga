namespace WarehouseAPI.Comman.Dtos
{
    public class ResponseCreateOrUpdateProductDto : RequestCreateOrUpdateProductDto
    {
        public Guid Id { get; set; }
    }
}
