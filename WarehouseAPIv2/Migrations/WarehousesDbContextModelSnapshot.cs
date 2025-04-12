﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseAPIv2.Infrastructure.Data;

#nullable disable

namespace WarehouseAPIv2.Migrations
{
    [DbContext(typeof(WarehousesDbContext))]
    partial class WarehousesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.14");

            modelBuilder.Entity("WarehouseAPIv2.Domain.Aggregate.EventAggregate.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AggregateId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDatetime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EventData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WarehouseAPIv2.Domain.Aggregate.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDatetime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UniversalProductCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("WarehouseAPIv2.Domain.Aggregate.ProductAggregate.Product", b =>
                {
                    b.OwnsOne("WarehouseAPIv2.Domain.Aggregate.ProductAggregate.CompanyInformation", "CompanyInformation", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("CompanyAddress")
                                .HasColumnType("TEXT")
                                .HasColumnName("CompanyAddress");

                            b1.Property<string>("CompanyEmail")
                                .HasColumnType("TEXT")
                                .HasColumnName("CompanyEmail");

                            b1.Property<string>("CompanyName")
                                .HasColumnType("TEXT")
                                .HasColumnName("CompanyName");

                            b1.Property<string>("CompanyPhone")
                                .HasColumnType("TEXT")
                                .HasColumnName("CompanyPhone");

                            b1.Property<string>("MadeCountry")
                                .HasColumnType("TEXT")
                                .HasColumnName("MadeCountry");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("WarehouseAPIv2.Domain.Aggregate.ProductAggregate.ProductDiscountPrice", "ProductDiscountPrice", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("DiscountPercentage")
                                .HasColumnType("REAL")
                                .HasColumnName("DiscountPercentage");

                            b1.Property<DateTime>("EndDiscount")
                                .HasColumnType("DATETIME")
                                .HasColumnName("EndDiscount");

                            b1.Property<decimal>("FinalPriceWithDiscount")
                                .HasColumnType("REAL")
                                .HasColumnName("FinalPriceWithDiscount");

                            b1.Property<decimal>("OriginalPrice")
                                .HasColumnType("REAL")
                                .HasColumnName("OriginalPrice");

                            b1.Property<DateTime>("StartDiscount")
                                .HasColumnType("DATETIME")
                                .HasColumnName("StartDiscount");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("WarehouseAPIv2.Domain.Aggregate.ProductAggregate.ProductPrice", "ProductPrice", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("FinalPrice")
                                .HasColumnType("REAL")
                                .HasColumnName("FinalPrice");

                            b1.Property<decimal>("PercentageProfitPrice")
                                .HasColumnType("REAL")
                                .HasColumnName("PercentageProfitPrice");

                            b1.Property<decimal>("PurchasePrice")
                                .HasColumnType("REAL")
                                .HasColumnName("PurchasePrice");

                            b1.Property<int>("Quantity")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Quantity");

                            b1.Property<int>("RemainingQuantity")
                                .HasColumnType("INTEGER")
                                .HasColumnName("RemainingQuantity");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("CompanyInformation")
                        .IsRequired();

                    b.Navigation("ProductDiscountPrice");

                    b.Navigation("ProductPrice");
                });
#pragma warning restore 612, 618
        }
    }
}
