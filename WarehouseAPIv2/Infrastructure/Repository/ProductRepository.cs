using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WarehouseAPIv2.Domain.ProductAggregate;
using WarehouseAPIv2.Domain.Repositories;
using WarehouseAPIv2.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WarehouseAPIv2.Infrastructure.Repository
{
    public class ProductRepository : IWarehouseRepository<Product>
    {
        private readonly WarehousesDbContext context;

        public ProductRepository(WarehousesDbContext warehousesDbContext)
        {
            this.context = warehousesDbContext;
        }
        async Task<Product> IWarehouseRepository<Product>.AddAsync(Product entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        async Task<bool> IWarehouseRepository<Product>.DeleteAsync(Product entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        IEnumerable<Product> IWarehouseRepository<Product>.GetAll(Expression<Func<Product, bool>> predicate)
        {
            return context.Products.Where(predicate);
        }

        async Task<Product?> IWarehouseRepository<Product>.GetByCodeAsync(string Code)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.UniversalProductCode == Code);

        }

        async Task<Product?> IWarehouseRepository<Product>.GetByIdAsync(Guid Id)
        {
            return await context.Products.Where(c => c.Id == Id).FirstOrDefaultAsync();
        }

        async Task<Product> IWarehouseRepository<Product>.UpdateAsync(Product entity)
        {
            context.Products.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
