using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addproductprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProductPrice",
                table: "Carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "271e944d-b22c-4662-8b2e-9b3a3793930a", "AQAAAAEAACcQAAAAEKBRqwkCDdZ/XSNt92DijOooE92tN7sormgk7vj6/JSHpCh34j3RwcvRHGcp/FJByw==", "1dcf2466-23fe-4ea1-8ef7-9b386f6ffe0d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89e891e1-3b4d-4d7e-997f-66d96db4b084", "AQAAAAEAACcQAAAAEOwnv+fDB+NmUGNypDiMcXzHzJUFW2RKohvX+8aA/G+cYBjGOg0sy2q39itpWuabOQ==", "9e536aa7-51eb-4e1a-ac4f-8947dcad3aa0" });
        }
    }
}
