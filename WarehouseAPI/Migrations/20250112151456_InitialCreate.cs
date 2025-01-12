using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseAPI.Migrations
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
                    ProductType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyInformation_CompanyAddress = table.Column<string>(type: "TEXT", nullable: true,name: "CompanyAddress"),
                    CompanyInformation_CompanyEmail = table.Column<string>(type: "TEXT", nullable: true, name: "CompanyEmail"),
                    CompanyInformation_CompanyName = table.Column<string>(type: "TEXT", nullable: true, name: "CompanyName"),
                    CompanyInformation_CompanyPhone = table.Column<string>(type: "TEXT", nullable: true, name: "CompanyPhone"),
                    CompanyInformation_MadeCountry = table.Column<string>(type: "TEXT", nullable: true, name: "MadeCountry")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDiscountPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartDiscount = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDiscount = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrginalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    FinalPriceWithDiscount = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscountPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDiscountPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDiscountPrices_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PercentageProfitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    RemainingQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountPrices_ProductId",
                table: "ProductDiscountPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountPrices_ProductId1",
                table: "ProductDiscountPrices",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId1",
                table: "ProductPrices",
                column: "ProductId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDiscountPrices");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
