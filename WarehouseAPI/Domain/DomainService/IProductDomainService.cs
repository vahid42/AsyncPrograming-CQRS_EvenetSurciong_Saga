namespace WarehouseAPI.Domain.DomainService
{
    public interface IProductDomainService
    {
        public Task<bool> DuplicateCodeCheck(string code);
    }
}
