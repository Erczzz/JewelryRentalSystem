using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class locationappointmentrel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "945c2b33-84c6-41d2-8ad0-ff70ac9180e7", "AQAAAAEAACcQAAAAEPQ5R6I3uadeUtencVtTxfm3DjB50FplkWn6F56Xtscdx/bOIuJb2AIappuB2mjAfA==", "2459879f-b3f1-401a-b1d9-becf4d83face" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Locations_LocationId",
                table: "Appointments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Locations_LocationId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53621132-7198-4b33-b92d-288892de9d34", "AQAAAAEAACcQAAAAEI3G+qkEal0BL0YLJM7BPXF4RVAdc3QVTR6aiMruSPjx54sOUZHy5S5Ey+l/JlH9vw==", "a04c5eff-fa58-4907-befb-293943748bcf" });
        }
    }
}
