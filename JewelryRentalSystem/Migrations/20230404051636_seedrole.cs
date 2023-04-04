using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class seedrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f749ed5-ec6f-410a-9c89-d37c3e498c0c", "3", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "1", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f913644d-d5a1-4c4a-a73b-dacc6a8c7898", "2", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f749ed5-ec6f-410a-9c89-d37c3e498c0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ea94376-bae3-4592-b2ef-16e2222ec6f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f913644d-d5a1-4c4a-a73b-dacc6a8c7898");
        }
    }
}
