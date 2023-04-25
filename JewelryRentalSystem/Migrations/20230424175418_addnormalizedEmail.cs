using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addnormalizedEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6373d25-0fd7-4cd1-8b82-2c178441f732", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDR2pjXNXQ4W6vGiWefqUPOz44RSBnSuiDSB3XiXjYazn+p4wORxmEx6sz5/gDfyNA==", "8b7dfa50-74e7-4e0f-b3aa-530094fb9dcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2003, 4, 25, 1, 54, 18, 88, DateTimeKind.Local).AddTicks(8358), "4932bbe7-39be-4730-9ca9-4d0e93d350d0", "ADMIN2@GMAIL.COM", "AQAAAAEAACcQAAAAENsOhnvdkzpnm9NcMbvLFZOxdx+Fnai02DvjDm3cDO4FagqIrwB7vCNsbhyhCIUZVQ==", "6054427b-b2a4-4676-bc09-3cc644895559" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa828dcd-e1bb-4c71-91aa-e13d858c299a", null, "AQAAAAEAACcQAAAAEIBCNIQAk3eNV0h+nXInzhZhZhhYMynWYgT/zFwrcJxaYzlYM2Ofx8JRQ+dNQxFyZg==", "edb516e3-3dd0-4759-8ae9-70d6929897e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2003, 4, 25, 1, 22, 40, 784, DateTimeKind.Local).AddTicks(7778), "e66655ff-eda8-49d5-bc37-5a7bc5a7958d", null, "AQAAAAEAACcQAAAAEJaOhT+callVU0FE5uusmzwxG80BA4B2VjnrnCkpuF4cmgFTc+uxf6SgGjPXTgso5Q==", "85c834db-b364-4a7c-9093-9307062feb33" });
        }
    }
}
