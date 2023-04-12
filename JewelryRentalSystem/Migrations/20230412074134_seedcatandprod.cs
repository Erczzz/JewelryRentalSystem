using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class seedcatandprod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628c13e2-3e69-4780-97ad-33770ec0c678", "AQAAAAEAACcQAAAAEMmZhuSWz0TDY0zSxserjSz0HSncXHxSBunZ7P4yZ4f1eg03r6meciUBKplG2BquTQ==", "9e772644-4c3d-4e8c-8954-64083f9b100e" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Ring" },
                    { 2, "Necklace" },
                    { 3, "Bracelet" },
                    { 4, "Earrings" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "ProductStock" },
                values: new object[] { 1, 4, "Add a pop of color and a touch of magical charm to your looks with this pair of Enchanted Disney Fine Jewelry Dangle Earrings. Featuring a 14k rose gold finish, these sterling silver earrings glitter with class and beauty. Glistening Rose De France complement the pure sparkle of 1/10 CTTW of diamonds. With these beautiful earrings, you won't need magic hair that glows when you sing in order to shine.", "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", "Enchanted Disney Fine Jewelry", 4000.0, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8fed842-ca39-495d-b51a-f0897e756c20", "AQAAAAEAACcQAAAAECtghaRjq4i0gK8kiypNudrb1+m4SppmUTYdyiXJ6mfb0n0ks+tOghojDzRa77oecg==", "0abde33e-edf8-4aeb-8cdb-528dd567747a" });
        }
    }
}
