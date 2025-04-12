
using WarehouseAPIv2.Comman;
using WarehouseAPIv2.Domain.Aggregate.ProductAggregate;
using WarehouseAPIv2.Domain.DomainService;
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
            builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddCommandHandlers(typeof(Program));
            builder.Services.AddQueryHandlers(typeof(Program));
          
            
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
