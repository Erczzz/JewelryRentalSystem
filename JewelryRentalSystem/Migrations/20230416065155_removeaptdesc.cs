using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class removeaptdesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APTDescription",
                table: "AppointmentTypes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c250a6c-94c7-46c1-af20-9732c537cd43", "AQAAAAEAACcQAAAAEAw4maqVn1JcL0OShLlP8acQ1IHFr9XVmGPwxNLOx8WzA3eeXkrrK16UWwVQaORktA==", "b45c24f7-3be1-4f50-aaf6-7c4ebd02174b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "APTDescription",
                table: "AppointmentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fde57615-a51b-4be2-a46a-4bd3e9edda3c", "AQAAAAEAACcQAAAAEOHGnwGyWvW8fY1PmBjEyhGjUBalKASUehQHavlqKII/0sf8CQCclBtE/zBizia9Xw==", "e0a9dbe4-247f-492a-b592-c8c3641a9b5e" });
        }
    }
}
