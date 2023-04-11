using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54f6b7ab-dba5-45cf-afc5-db32ce587a38", "AQAAAAEAACcQAAAAEC9uPgpjF6VSKWdP4fY1KP4L2G9yxiGzuZm7rCENGCWsog4//T11D10yV28Hr44NGw==", "c35d60e9-787f-4373-9fdc-91b85d7e1fd2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "377e7ea2-1182-46fa-b40a-afaf20bead2e", "AQAAAAEAACcQAAAAEHpldgy7Opppl0UZ6ATPh0FAmu+A6xmnHUANetIQwhe7WYC7E1aw3aEfI2xu01vKyA==", "580aaca2-919e-48e4-8131-dd1b225e4be5" });
        }
    }
}
