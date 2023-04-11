using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class removetransactionid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Transactions_TransactionId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a367e46d-6295-41ce-aa32-9f54e05d9cf7", "AQAAAAEAACcQAAAAEOVLyvkFN8H0/vpNrvTZ1GL10sVgPn7YTJvAtZS8uwuPdRqrLHXmhAPswm9qvIXWUw==", "5c5a1bf8-a920-4604-94f7-3090c610c61d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Transactions_TransactionId",
                table: "Carts",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Transactions_TransactionId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Carts",
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
                values: new object[] { "2a860d12-d7b2-4c4e-a0cc-820dab3ef021", "AQAAAAEAACcQAAAAEDI5gXXg39eCxshC/eUCguMJpYKhYBwAllo0xNEl+f3hxJRnKj3OoXurS6V9lko5GQ==", "39c09e68-6e48-4835-972f-2d6342048e76" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Transactions_TransactionId",
                table: "Carts",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
