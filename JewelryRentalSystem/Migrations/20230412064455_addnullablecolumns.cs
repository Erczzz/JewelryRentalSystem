using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addnullablecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConfirmAppointment",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8fed842-ca39-495d-b51a-f0897e756c20", "AQAAAAEAACcQAAAAECtghaRjq4i0gK8kiypNudrb1+m4SppmUTYdyiXJ6mfb0n0ks+tOghojDzRa77oecg==", "0abde33e-edf8-4aeb-8cdb-528dd567747a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmAppointment",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6564fa55-edb6-48f7-bc11-9e023afb354f", "AQAAAAEAACcQAAAAED+aDY2KD96U1+VZ25wKcNo43suwk9ldnq6DioFPLEUlWRnuJLZVpaF5gQqtZpXIrQ==", "599ac8cd-7e3d-47d3-81a0-42ec42ce44f8" });
        }
    }
}
