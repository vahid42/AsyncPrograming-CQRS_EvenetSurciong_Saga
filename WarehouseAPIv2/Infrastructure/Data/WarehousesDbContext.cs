using System;
using Microsoft.EntityFrameworkCore;
using WarehouseAPIv2.Domain.Aggregate.EventAggregate;
using WarehouseAPIv2.Domain.Aggregate.ProductAggregate;

namespace WarehouseAPIv2.Infrastructure.Data
{
    public class WarehousesDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Event> Events { get; set; }

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
            modelBuilder.Entity<Product>(p =>
            {

                p.HasKey(p => p.Id);
                p.Ignore(p => p.DomainEvents);
            });
            
            modelBuilder.Entity<Event>(@event =>
            {
                @event.HasKey(p => p.Id);
                @event.Property(c => c.CreateDatetime).HasColumnType("DATETIME");
            });



            #region complex property
            //modelBuilder.Entity<Product>().ComplexProperty(p => p.CompanyInformation);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.Property<DateTime>("CreateDatetime").HasColumnType("DATETIME");
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
                entity.OwnsOne(p => p.ProductPrice, productPrice =>
                {
                    productPrice.Property(ci => ci.PurchasePrice)
                        .HasColumnName("PurchasePrice")
                        .HasColumnType("REAL");

                    productPrice.Property(ci => ci.FinalPrice)
                        .HasColumnName("FinalPrice")
                        .HasColumnType("REAL");

                    productPrice.Property(ci => ci.PercentageProfitPrice)
                        .HasColumnName("PercentageProfitPrice")
                        .HasColumnType("REAL");

                    productPrice.Property(ci => ci.Quantity)
                        .HasColumnName("Quantity");

                    productPrice.Property(ci => ci.RemainingQuantity)
                        .HasColumnName("RemainingQuantity");
                });
                entity.OwnsOne(p => p.ProductDiscountPrice, productDiscount =>
                {
                    productDiscount.Property(ci => ci.StartDiscount)
                    .HasColumnName("StartDiscount")
                    .HasColumnType("DATETIME");

                    productDiscount.Property(ci => ci.EndDiscount)
                        .HasColumnName("EndDiscount")
                        .HasColumnType("DATETIME");

                    productDiscount.Property(ci => ci.DiscountPercentage)
                        .HasColumnName("DiscountPercentage")
                        .HasColumnType("REAL");

                    productDiscount.Property(ci => ci.OriginalPrice)
                        .HasColumnName("OriginalPrice")
                        .HasColumnType("REAL");

                    productDiscount.Property(ci => ci.FinalPriceWithDiscount)
                        .HasColumnName("FinalPriceWithDiscount")
                        .HasColumnType("REAL");

                });
            });
            #endregion

        }

        private string DbPath { get; }
        private static string Init()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return System.IO.Path.Join(path, "Warehousev2DB.db");
        }
    }
}
