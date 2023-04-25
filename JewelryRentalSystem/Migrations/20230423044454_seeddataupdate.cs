using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class seeddataupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerClassName",
                table: "ProfileViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ItemLimit",
                table: "ProfileViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentLimit",
                table: "ProfileViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fad4857-cfd6-4fa6-91dc-4628aa10108a", "AQAAAAEAACcQAAAAEExbrl4Doma+NP+g7jqIiKlEouI3ldyg0HHTG/owdfTapLpCNlJuSv6wWOIalTbSQg==", "47e82973-1056-4b41-ae87-70bba290e0f3" });

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 1,
                column: "CustomerClassName",
                value: "CLassic");

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 2,
                column: "CustomerClassName",
                value: "Silver");

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 3,
                column: "CustomerClassName",
                value: "Gold");

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 4,
                column: "CustomerClassName",
                value: "Platinum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerClassName",
                table: "ProfileViewModel");

            migrationBuilder.DropColumn(
                name: "ItemLimit",
                table: "ProfileViewModel");

            migrationBuilder.DropColumn(
                name: "RentLimit",
                table: "ProfileViewModel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb17d16-8e90-4506-9c5b-f3ebe0bf1716", "AQAAAAEAACcQAAAAEBL10H+WtDGSfeg7B8sjfGuoUbbxH9KRkR6qgHxDjfMEY1acfnHG/dGZVqUgkDhT6A==", "4923f3e5-ae7e-47a4-a2ae-07c9fc9bfb7b" });

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 1,
                column: "CustomerClassName",
                value: "Low");

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 2,
                column: "CustomerClassName",
                value: "Med");

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 3,
                column: "CustomerClassName",
                value: "High");

            migrationBuilder.UpdateData(
                table: "CustomerClassifications",
                keyColumn: "CustomerClassId",
                keyValue: 4,
                column: "CustomerClassName",
                value: "Superior");
        }
    }
}
