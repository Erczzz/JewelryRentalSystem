using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updaterel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId",
                table: "ScheduleTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId1",
                table: "ScheduleTimes");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleTimes_AppointmentId",
                table: "ScheduleTimes");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleTimes_AppointmentId1",
                table: "ScheduleTimes");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "ScheduleTimes");

            migrationBuilder.DropColumn(
                name: "AppointmentId1",
                table: "ScheduleTimes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53621132-7198-4b33-b92d-288892de9d34", "AQAAAAEAACcQAAAAEI3G+qkEal0BL0YLJM7BPXF4RVAdc3QVTR6aiMruSPjx54sOUZHy5S5Ey+l/JlH9vw==", "a04c5eff-fa58-4907-befb-293943748bcf" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeId",
                table: "Appointments",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ScheduleTimes_TimeId",
                table: "Appointments",
                column: "TimeId",
                principalTable: "ScheduleTimes",
                principalColumn: "TimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ScheduleTimes_TimeId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "ScheduleTimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId1",
                table: "ScheduleTimes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dbc95f3-b0c6-450e-a4cd-8bcd96ae2e6a", "AQAAAAEAACcQAAAAEJ1rNqnOUHa383bjqmH+metA8/h84xC4ZPFWBRgKcSCGimkYfyzoEIRf/tttk9yfmw==", "8e627b96-7180-4c08-a4e4-f37487954a5b" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimes_AppointmentId",
                table: "ScheduleTimes",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimes_AppointmentId1",
                table: "ScheduleTimes",
                column: "AppointmentId1",
                unique: true,
                filter: "[AppointmentId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId",
                table: "ScheduleTimes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTimes_Appointments_AppointmentId1",
                table: "ScheduleTimes",
                column: "AppointmentId1",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");
        }
    }
}
