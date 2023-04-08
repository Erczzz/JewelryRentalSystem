using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class seeddatatime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d90476b-3d99-44c4-8718-9afc15db69f2", "AQAAAAEAACcQAAAAEEocE7tApnZMBCXjXWzMe3sCiDI+HtQBx8qOpEWHHQ+Gxlaz6JUDXVSILgKcoQPh4Q==", "1d479834-f6a8-48a3-bf6d-1d8043febd62" });

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
                values: new object[] { "a9a9592c-0c7c-4a3c-af96-de084f4608e0", "AQAAAAEAACcQAAAAEL8szacrhpeRofo1GLpB/u/jxiQM1yO4xykj4bWY1z8xtkxB1Ct+6Vd5gRmOt7U5Rg==", "fa7f41ea-4b27-4d5e-a307-337765d163bb" });
        }


    }
}
