
using WarehouseAPI.Domain.DomainService;
using WarehouseAPI.Domain.ProductAggregate;
using WarehouseAPI.Domain.Repositories;
using WarehouseAPI.Infrastructure;
using WarehouseAPI.Infrastructure.Data;
using WarehouseAPI.Infrastructure.Repository;

namespace WarehouseAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<WarehousesDbContext>();
            builder.Services.AddScoped<IWarehouseRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
            builder.Services.AddCommandHandlers(typeof(Program));
            builder.Services.AddQueryHandlers(typeof(Program));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}