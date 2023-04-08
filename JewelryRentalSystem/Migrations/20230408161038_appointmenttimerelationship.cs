using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class appointmenttimerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "ScheduleTimes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0901a56-714b-4cf4-aa23-a49c6719572e", "AQAAAAEAACcQAAAAEMVciXpFNPNcE/bgIvC4hoQPf+dYRlpXF5Vz/p/DONd3YJkjXYK2aiTHvpYTkHAmhw==", "ecd768d5-d496-409b-afaf-fadf4f78f34b" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimes_AppointmentId",
                table: "ScheduleTimes",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId",
                table: "ScheduleTimes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId",
                table: "ScheduleTimes");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleTimes_AppointmentId",
                table: "ScheduleTimes");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "ScheduleTimes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54e32842-e371-4f48-afc9-7257d7b0ab41", "AQAAAAEAACcQAAAAEJrQ/8Y9KZW91Ffkbha7zNN/D3s+XgR8/Wu1qa3DHbrS/MONXkGKDKZd3eScTyNCQA==", "a8d471d4-c83c-41a1-bd0b-775a27d4b38f" });
        }
    }
}
