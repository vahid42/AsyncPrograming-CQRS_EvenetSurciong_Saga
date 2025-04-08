using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseAPIv2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    UniversalProductCode = table.Column<string>(type: "TEXT", nullable: true),
                    ProductType = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyAddress = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPhone = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyEmail = table.Column<string>(type: "TEXT", nullable: true),
                    MadeCountry = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "REAL", nullable: true),
                    PercentageProfitPrice = table.Column<decimal>(type: "REAL", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "REAL", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    RemainingQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    StartDiscount = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    EndDiscount = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "REAL", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "REAL", nullable: true),
                    FinalPriceWithDiscount = table.Column<decimal>(type: "REAL", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
