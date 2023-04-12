using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updateentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6564fa55-edb6-48f7-bc11-9e023afb354f", "AQAAAAEAACcQAAAAED+aDY2KD96U1+VZ25wKcNo43suwk9ldnq6DioFPLEUlWRnuJLZVpaF5gQqtZpXIrQ==", "599ac8cd-7e3d-47d3-81a0-42ec42ce44f8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc48e4aa-dec9-462f-ad23-8333236d63bd", "AQAAAAEAACcQAAAAECedvSDYghK0bsJKcVdlZdE172CJ7mn8yn1PaDa6JlmkG2YTNq1cxLZo8b0ys4VwZg==", "f04d1992-a138-4450-8879-5fd76faf4919" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
