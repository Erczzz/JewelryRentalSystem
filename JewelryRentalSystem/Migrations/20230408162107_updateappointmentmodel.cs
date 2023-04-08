using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updateappointmentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId1",
                table: "ScheduleTimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dbc95f3-b0c6-450e-a4cd-8bcd96ae2e6a", "AQAAAAEAACcQAAAAEJ1rNqnOUHa383bjqmH+metA8/h84xC4ZPFWBRgKcSCGimkYfyzoEIRf/tttk9yfmw==", "8e627b96-7180-4c08-a4e4-f37487954a5b" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimes_AppointmentId1",
                table: "ScheduleTimes",
                column: "AppointmentId1",
                unique: true,
                filter: "[AppointmentId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId1",
                table: "ScheduleTimes",
                column: "AppointmentId1",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId1",
                table: "ScheduleTimes");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleTimes_AppointmentId1",
                table: "ScheduleTimes");

            migrationBuilder.DropColumn(
                name: "AppointmentId1",
                table: "ScheduleTimes");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0901a56-714b-4cf4-aa23-a49c6719572e", "AQAAAAEAACcQAAAAEMVciXpFNPNcE/bgIvC4hoQPf+dYRlpXF5Vz/p/DONd3YJkjXYK2aiTHvpYTkHAmhw==", "ecd768d5-d496-409b-afaf-fadf4f78f34b" });
        }
    }
}
