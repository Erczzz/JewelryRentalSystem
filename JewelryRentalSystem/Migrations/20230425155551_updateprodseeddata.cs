using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class updateprodseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "ModifyAccountViewModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfb28322-5edc-48ed-96b0-330a71091926", "AQAAAAEAACcQAAAAEKZ8bAsAAu/zK0Or4CqU4m0ZNMgirVYFjwAv3paC5PAQbSS/wKLc80znQPdqd+U9TQ==", "e09fa62f-1bb5-4006-b2f4-1262af53b77f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2003, 4, 25, 23, 55, 50, 767, DateTimeKind.Local).AddTicks(848), "4092c772-9d04-4049-b862-68574cea287e", "AQAAAAEAACcQAAAAEIm1HCLM8wXZrwubNJB6D0lW8Ajjw1Von16CE285BJJWpY6TIQ9ehS4eBaVBELVhyg==", "9b80ccd6-5671-48d6-9242-fc6f755915ab" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CustClassId", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[] { 2, "Dress up like your favorite Disney Princess Snow White by wearing this Enchanted Disney Fine Jewelry Sterling Silver and 10K Rose Gold Ring with Diamond Accent and Red Garnet. Evoking the gentle yet stern personality of Disney's first princess, this ring is all about female empowerment. It's the jewel for the independent lady who still loves fashion pretend play but does it in a chic, stylish, and very sophisticated way.", "Diamond and Red Garnet Snow White Ring", 2450.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "ModifyAccountViewModel",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf498b1b-02a5-456d-ae91-4f13386a5b5d", "AQAAAAEAACcQAAAAEOrIT4C1AvpXu820u43yeJhb6gsTZPCqnCG27t+sAJ0FU0fEWXgUPI/sNW5oBC7Rdw==", "322f6487-d51b-4054-acb8-12d8e2768c6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2003, 4, 25, 2, 27, 9, 826, DateTimeKind.Local).AddTicks(4114), "1d3e74b2-b560-40ea-ba43-f4d23093451e", "AQAAAAEAACcQAAAAEHzN5gakMp/lVR5yLs5rPL/+uQMNo/g2P9SJmFfn5McOMTWV5NpqqkGIswliKW+XAA==", "668978ac-82b5-426f-a63e-156bb448e9d2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CustClassId", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[] { 3, "A mysterious bloom carrying many meanings. The black rose, in this Disney Villain ring, actually stands for rebirth and new beginnings. Get this as a token to honor a major change in your life. A creation from the Enchanted Disney Fine Jewelry Collection, this Maleficent Ring features a thorn-inspired sterling silver band plated in black rhodium.", "Maleficent Rose Ring", 4000.0 });
        }
    }
}
