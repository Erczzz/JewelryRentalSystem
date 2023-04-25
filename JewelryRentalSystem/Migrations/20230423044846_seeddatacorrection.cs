using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class seeddatacorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78c13626-f448-4a3c-adda-7c77a6fdc7f4", "AQAAAAEAACcQAAAAEKlbQZqCcwftRMXt5WoyRHJBnpOv0glPsLUoIq+tWfFrmo9rLF7O60d8GNLPCkgQhA==", "169b69d4-8b19-41be-80a9-1d5cabfa77a0" });

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 1,
                column: "CustomerClassName",
                value: "Classic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fad4857-cfd6-4fa6-91dc-4628aa10108a", "AQAAAAEAACcQAAAAEExbrl4Doma+NP+g7jqIiKlEouI3ldyg0HHTG/owdfTapLpCNlJuSv6wWOIalTbSQg==", "47e82973-1056-4b41-ae87-70bba290e0f3" });

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 1,
                column: "CustomerClassName",
                value: "CLassic");
        }
    }
}
