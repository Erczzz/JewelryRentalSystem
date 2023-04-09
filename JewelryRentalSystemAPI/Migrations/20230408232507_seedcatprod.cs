using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryRentalSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedcatprod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Ring" },
                    { 2, "Necklace" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "CategoryId", "ProductId", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "ProductStock" },
                values: new object[,]
                {
                    { 1, 1, "Test", "Test", "Diamond Ring", 20000.0, 2 },
                    { 2, 2, "Test", "Test", "Pearl Necklace", 15000.0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);
        }
    }
}
