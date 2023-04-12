using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class seedefaulttime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc48e4aa-dec9-462f-ad23-8333236d63bd", "AQAAAAEAACcQAAAAECedvSDYghK0bsJKcVdlZdE172CJ7mn8yn1PaDa6JlmkG2YTNq1cxLZo8b0ys4VwZg==", "f04d1992-a138-4450-8879-5fd76faf4919" });

            migrationBuilder.InsertData(
                table: "ScheduleTimes",
                columns: new[] { "TimeId", "SchedTime" },
                values: new object[,]
                {
                    { 1, "8:00:00 - 9:00:00" },
                    { 2, "9:00:00 - 10:00:00" },
                    { 3, "10:00:00 - 11:00:00" },
                    { 4, "11:00:00 - 12:00:00" },
                    { 5, "13:00:00 - 14:00:00" },
                    { 6, "14:00:00 - 15:00:00" },
                    { 7, "15:00:00 - 16:00:00" },
                    { 8, "16:00:00 - 17:00:00" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ScheduleTimes",
                keyColumn: "TimeId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a367e46d-6295-41ce-aa32-9f54e05d9cf7", "AQAAAAEAACcQAAAAEOVLyvkFN8H0/vpNrvTZ1GL10sVgPn7YTJvAtZS8uwuPdRqrLHXmhAPswm9qvIXWUw==", "5c5a1bf8-a920-4604-94f7-3090c610c61d" });
        }
    }
}
