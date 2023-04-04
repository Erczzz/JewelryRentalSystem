using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updateapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 1, "Administrator" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 2, "Employee" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 3, "Customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BirthDate", "ContactNo", "Email", "FirstName", "LastName", "RoleId", "Username" },
                values: new object[] { 1, "SampleAddress", new DateTime(1999, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "09920098321", "admin@email.com", "Admin", "Admin", 1, "admin" });
        }
    }
}
