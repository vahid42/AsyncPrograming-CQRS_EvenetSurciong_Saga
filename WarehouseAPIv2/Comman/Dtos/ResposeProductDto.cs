namespace WarehouseAPIv2.Comman.Dtos
{
    public class ResposeProductDto : ProductDto
    {
        public Guid Id { get; set; }
        public DateTime CreateDatetime { get; set; }
        public bool IsActive { get; set; }

    }
}
