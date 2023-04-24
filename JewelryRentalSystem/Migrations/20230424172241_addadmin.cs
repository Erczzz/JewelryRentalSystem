using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa828dcd-e1bb-4c71-91aa-e13d858c299a", "AQAAAAEAACcQAAAAEIBCNIQAk3eNV0h+nXInzhZhZhhYMynWYgT/zFwrcJxaYzlYM2Ofx8JRQ+dNQxFyZg==", "edb516e3-3dd0-4759-8ae9-70d6929897e3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthdate", "ConcurrencyStamp", "ContactNo", "CustClassId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isActive" },
                values: new object[] { "45e23747-27a5-48e9-b7a6-755bfbb86004", 0, "Sample Address", new DateTime(2003, 4, 25, 1, 22, 40, 784, DateTimeKind.Local).AddTicks(7778), "e66655ff-eda8-49d5-bc37-5a7bc5a7958d", "09876543211", 5, "admin2@gmail.com", false, "admin", "admin", false, null, null, "ADMIN2@GMAIL.COM", "AQAAAAEAACcQAAAAEJaOhT+callVU0FE5uusmzwxG80BA4B2VjnrnCkpuF4cmgFTc+uxf6SgGjPXTgso5Q==", null, false, "85c834db-b364-4a7c-9093-9307062feb33", false, "admin2@gmail.com", true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "45e23747-27a5-48e9-b7a6-755bfbb86004" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "45e23747-27a5-48e9-b7a6-755bfbb86004" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78c13626-f448-4a3c-adda-7c77a6fdc7f4", "AQAAAAEAACcQAAAAEKlbQZqCcwftRMXt5WoyRHJBnpOv0glPsLUoIq+tWfFrmo9rLF7O60d8GNLPCkgQhA==", "169b69d4-8b19-41be-80a9-1d5cabfa77a0" });
        }
    }
}
