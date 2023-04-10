using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class removetotalamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmountToBePaid",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "ProfileViewModel",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViewModel", x => x.CustomerId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "377e7ea2-1182-46fa-b40a-afaf20bead2e", "AQAAAAEAACcQAAAAEHpldgy7Opppl0UZ6ATPh0FAmu+A6xmnHUANetIQwhe7WYC7E1aw3aEfI2xu01vKyA==", "580aaca2-919e-48e4-8131-dd1b225e4be5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileViewModel");

            migrationBuilder.AddColumn<double>(
                name: "TotalAmountToBePaid",
                table: "Appointments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8a9aaf9-3817-4126-bb1c-40daa7c42d0b", "AQAAAAEAACcQAAAAEEpdiOQOMb3XY/dTxbMwbv2C6qF5xt7qV4fZjYZOBsyr9KNAZVqTc7wmbGXJIq3b6w==", "1ff4fdcc-03fe-47ec-b3f7-f93d7bf62d80" });
        }
    }
}
