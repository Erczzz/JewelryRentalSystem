using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addcustomerclassification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustClassId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustClassId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivateAccountViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivateAccountViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerClassifications",
                columns: table => new
                {
                    CustomerClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemLimit = table.Column<int>(type: "int", nullable: false),
                    RentLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerClassifications", x => x.CustomerClassId);
                });

            migrationBuilder.CreateTable(
                name: "ModifyAccountViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifyAccountViewModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CustomerClassifications",
                columns: new[] { "CustomerClassId", "CustomerClassName", "ItemLimit", "RentLimit" },
                values: new object[,]
                {
                    { 1, "Low", 5, 1 },
                    { 2, "Med", 10, 5 },
                    { 3, "High", 20, 10 },
                    { 4, "Superior", 0, 0 },
                    { 5, "Admin", 0, 0 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CustClassId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb17d16-8e90-4506-9c5b-f3ebe0bf1716", 5, "AQAAAAEAACcQAAAAEBL10H+WtDGSfeg7B8sjfGuoUbbxH9KRkR6qgHxDjfMEY1acfnHG/dGZVqUgkDhT6A==", "4923f3e5-ae7e-47a4-a2ae-07c9fc9bfb7b" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CustClassId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustClassId",
                table: "Products",
                column: "CustClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustClassId",
                table: "AspNetUsers",
                column: "CustClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomerClassifications_CustClassId",
                table: "AspNetUsers",
                column: "CustClassId",
                principalTable: "CustomerClassifications",
                principalColumn: "CustomerClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CustomerClassifications_CustClassId",
                table: "Products",
                column: "CustClassId",
                principalTable: "CustomerClassifications",
                principalColumn: "CustomerClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomerClassifications_CustClassId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CustomerClassifications_CustClassId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ActivateAccountViewModel");

            migrationBuilder.DropTable(
                name: "CustomerClassifications");

            migrationBuilder.DropTable(
                name: "ModifyAccountViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Products_CustClassId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustClassId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustClassId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustClassId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c250a6c-94c7-46c1-af20-9732c537cd43", "AQAAAAEAACcQAAAAEAw4maqVn1JcL0OShLlP8acQ1IHFr9XVmGPwxNLOx8WzA3eeXkrrK16UWwVQaORktA==", "b45c24f7-3be1-4f50-aaf6-7c4ebd02174b" });
        }
    }
}
