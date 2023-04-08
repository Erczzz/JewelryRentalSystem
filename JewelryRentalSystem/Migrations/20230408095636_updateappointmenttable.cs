using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updateappointmenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "TimeOfAppointment",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                values: new object[] { "ac0587e8-af54-4cf2-bb09-0589df2fd0c4", "AQAAAAEAACcQAAAAEPlOCkR0qsMFqp/COj9+Qx9C/tjZ0oH1O8LCxzN3TjQgra7+A9LXNBI7wdYfpw0gFQ==", "a571ef01-26c2-48f3-86d7-d7fbf5c96d33" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfAppointment",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TotalAmountToBePaid",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "271e944d-b22c-4662-8b2e-9b3a3793930a", "AQAAAAEAACcQAAAAEKBRqwkCDdZ/XSNt92DijOooE92tN7sormgk7vj6/JSHpCh34j3RwcvRHGcp/FJByw==", "1dcf2466-23fe-4ea1-8ef7-9b386f6ffe0d" });
        }
    }
}
