using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using WarehouseAPI.Domain.ProductAggregate;

namespace WarehouseAPI.Infrastructure.Data
{
    public class WarehousesDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDiscountPrice> ProductDiscountPrices { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public WarehousesDbContext(DbContextOptions<WarehousesDbContext> options) : base(options)
        {
            //"C:\\Users\\Laptop-V\\AppData\\Local\\Order.db"
            this.DbPath = Init();

            //Add-Migration InitialCreate
            //Update-Database
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasMany<ProductDiscountPrice>()
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
           .HasMany<ProductPrice>()
           .WithOne(p => p.Product)
           .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
           .Property(p => p.CompanyInformation)
           .HasConversion(
               p => new { p.CompanyName, p.CompanyAddress, p.CompanyEmail, p.MadeCountry, p.CompanyPhone },  // Convert Money to a tuple  
               p => new CompanyInformation(p.CompanyName, p.CompanyAddress, p.CompanyEmail, p.MadeCountry, p.CompanyPhone) // Convert tuple back to Money  
           );
        }
          
        private string DbPath { get; }
        private static string Init()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return System.IO.Path.Join(path, "OrderDB.db");
        }
    }
}
