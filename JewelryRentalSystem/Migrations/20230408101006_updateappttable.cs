using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updateappttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAppointment",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46f981b1-35d1-4fbf-a153-e2e2e75b7921", "AQAAAAEAACcQAAAAENBvTCL4zFA/+YksqfDkoATC3Tg3ZEn2YXPL/5B+yy22fW0aZOFE24PITtZjJbDcEA==", "6b3c437a-02b9-4991-8295-fc6f59ddbe24" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfAppointment",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac0587e8-af54-4cf2-bb09-0589df2fd0c4", "AQAAAAEAACcQAAAAEPlOCkR0qsMFqp/COj9+Qx9C/tjZ0oH1O8LCxzN3TjQgra7+A9LXNBI7wdYfpw0gFQ==", "a571ef01-26c2-48f3-86d7-d7fbf5c96d33" });
        }
    }
}
