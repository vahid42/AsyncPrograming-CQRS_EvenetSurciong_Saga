
using WarehouseAPIv2.Domain.ProductAggregate;
using WarehouseAPIv2.Domain.Repositories;
using WarehouseAPIv2.Infrastructure.Data;
using WarehouseAPIv2.Infrastructure.Repository;

namespace WarehouseAPIv2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<WarehousesDbContext>();
            builder.Services.AddScoped<IWarehouseRepository<Product>, ProductRepository>();
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
