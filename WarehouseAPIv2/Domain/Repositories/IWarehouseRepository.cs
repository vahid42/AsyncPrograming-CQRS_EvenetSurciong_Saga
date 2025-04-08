using System.Linq.Expressions;

namespace WarehouseAPIv2.Domain.Repositories
{
    public interface IWarehouseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>> predicate);
        Task<T?> GetByIdAsync(Guid Id);
        Task<T?> GetByCodeAsync(string Code);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);


    }
}
