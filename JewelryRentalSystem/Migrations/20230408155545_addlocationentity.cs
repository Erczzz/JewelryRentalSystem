using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addlocationentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54e32842-e371-4f48-afc9-7257d7b0ab41", "AQAAAAEAACcQAAAAEJrQ/8Y9KZW91Ffkbha7zNN/D3s+XgR8/Wu1qa3DHbrS/MONXkGKDKZd3eScTyNCQA==", "a8d471d4-c83c-41a1-bd0b-775a27d4b38f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d90476b-3d99-44c4-8718-9afc15db69f2", "AQAAAAEAACcQAAAAEEocE7tApnZMBCXjXWzMe3sCiDI+HtQBx8qOpEWHHQ+Gxlaz6JUDXVSILgKcoQPh4Q==", "1d479834-f6a8-48a3-bf6d-1d8043febd62" });
        }
    }
}
