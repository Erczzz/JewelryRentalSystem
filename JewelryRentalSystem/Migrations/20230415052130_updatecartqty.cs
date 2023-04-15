using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updatecartqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductQty",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3061c17-4706-48a4-94d7-c6d5b6888fc2", "AQAAAAEAACcQAAAAEKZK3Vt7ZwENbhUjP7+UYXShRpwELgASB9Jdy2YCGfdC651SQE0d0KILwkGfK+RoKA==", "903b2aae-27ae-471a-b71d-2a9fb999b2aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ProductQty",
                table: "Carts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628c13e2-3e69-4780-97ad-33770ec0c678", "AQAAAAEAACcQAAAAEMmZhuSWz0TDY0zSxserjSz0HSncXHxSBunZ7P4yZ4f1eg03r6meciUBKplG2BquTQ==", "9e772644-4c3d-4e8c-8954-64083f9b100e" });
        }
    }
}
