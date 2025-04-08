namespace WarehouseAPIv2.Domain.DomainService
{
    public interface IProductDomainService
    {
        public Task<bool> DuplicateCodeCheck(string UniversalProductCode);
     }
}
