using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addadminandroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f749ed5-ec6f-410a-9c89-d37c3e498c0c",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "7f749ed5-ec6f-410a-9c89-d37c3e498c0c", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ea94376-bae3-4592-b2ef-16e2222ec6f4",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f913644d-d5a1-4c4a-a73b-dacc6a8c7898",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "f913644d-d5a1-4c4a-a73b-dacc6a8c7898", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthdate", "ConcurrencyStamp", "ContactNo", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "Sample Address", null, "0ba27a79-1746-41ff-9ad3-8ad4104c43ec", "09876543211", "admin@gmail.com", false, "admin", "admin", false, null, null, "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEK22XxPi1l0gS4nxUjMHDQVgsK7jhI7nIe58dHwyDY594gjV2kbsSpD2rL4e8kz97g==", null, false, "240ab6e9-4e2d-4b00-bce2-0ee5fd302cab", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f749ed5-ec6f-410a-9c89-d37c3e498c0c",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "3", "Employee" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ea94376-bae3-4592-b2ef-16e2222ec6f4",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "1", "Administrator" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f913644d-d5a1-4c4a-a73b-dacc6a8c7898",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "2", "Customer" });
        }
    }
}
