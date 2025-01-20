namespace WarehouseAPI.Domain.DomainService
{
    public interface IProductDomainService
    {
        public Task<bool> DuplicateCodeCheck(string UniversalProductCode);
        public Task<bool> ActiveCurrentProductPrice(string UniversalProductCode);
    }
}
