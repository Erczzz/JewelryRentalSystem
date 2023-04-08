using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addTimeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f749ed5-ec6f-410a-9c89-d37c3e498c0c");

            migrationBuilder.CreateTable(
                name: "ScheduleTimes",
                columns: table => new
                {
                    TimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchedTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTimes", x => x.TimeId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9a9592c-0c7c-4a3c-af96-de084f4608e0", "AQAAAAEAACcQAAAAEL8szacrhpeRofo1GLpB/u/jxiQM1yO4xykj4bWY1z8xtkxB1Ct+6Vd5gRmOt7U5Rg==", "fa7f41ea-4b27-4d5e-a307-337765d163bb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleTimes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f749ed5-ec6f-410a-9c89-d37c3e498c0c", "7f749ed5-ec6f-410a-9c89-d37c3e498c0c", "Employee", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46f981b1-35d1-4fbf-a153-e2e2e75b7921", "AQAAAAEAACcQAAAAENBvTCL4zFA/+YksqfDkoATC3Tg3ZEn2YXPL/5B+yy22fW0aZOFE24PITtZjJbDcEA==", "6b3c437a-02b9-4991-8295-fc6f59ddbe24" });
        }
    }
}
