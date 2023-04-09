using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updateappointmententity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8a9aaf9-3817-4126-bb1c-40daa7c42d0b", "AQAAAAEAACcQAAAAEEpdiOQOMb3XY/dTxbMwbv2C6qF5xt7qV4fZjYZOBsyr9KNAZVqTc7wmbGXJIq3b6w==", "1ff4fdcc-03fe-47ec-b3f7-f93d7bf62d80" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "945c2b33-84c6-41d2-8ad0-ff70ac9180e7", "AQAAAAEAACcQAAAAEPQ5R6I3uadeUtencVtTxfm3DjB50FplkWn6F56Xtscdx/bOIuJb2AIappuB2mjAfA==", "2459879f-b3f1-401a-b1d9-becf4d83face" });
        }
    }
}
