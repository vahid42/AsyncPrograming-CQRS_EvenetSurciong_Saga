using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text.Json;
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
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductDiscountPrice>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductPrice>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
            .HasMany<ProductDiscountPrice>()
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
           .HasMany<ProductPrice>()
           .WithOne(p => p.Product)
           .HasForeignKey(p => p.ProductId);



            #region complex property
            //modelBuilder.Entity<Product>().ComplexProperty(p => p.CompanyInformation);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products"); // Assuming your table is named `Products`  

                // Configure 'CompanyInformation' as a complex property  
               // OwnsOne(...): This method is used to define CompanyInformation as a complex type(owned entity). This means CompanyInformation will not have its own table but will be stored in the Products table.
                entity.OwnsOne(p => p.CompanyInformation, companyInfo =>
                {
                    companyInfo.Property(ci => ci.CompanyAddress)
                    .HasColumnName("CompanyAddress")
                    .HasColumnType("TEXT")
                        .IsRequired(false); // nullable  

                    companyInfo.Property(ci => ci.CompanyEmail)
                        .HasColumnName("CompanyEmail")
                        .HasColumnType("TEXT")
                        .IsRequired(false); // nullable  

                    companyInfo.Property(ci => ci.CompanyName)
                        .HasColumnName("CompanyName")
                        .HasColumnType("TEXT")
                        .IsRequired(false); // nullable  

                    companyInfo.Property(ci => ci.CompanyPhone)
                        .HasColumnName("CompanyPhone")
                        .HasColumnType("TEXT")
                        .IsRequired(false); // nullable  

                    companyInfo.Property(ci => ci.MadeCountry)
                        .HasColumnName("MadeCountry")
                        .HasColumnType("TEXT")
                        .IsRequired(false); // nullable  
                });
            });
            #endregion

        }

        private string DbPath { get; }
        private static string Init()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return System.IO.Path.Join(path, "WarehouseDB.db");
        }
    }
}
