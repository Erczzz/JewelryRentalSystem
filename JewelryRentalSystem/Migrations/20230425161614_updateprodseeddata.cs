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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f8e022b-2f2f-42d6-bf86-145cce520c34", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJpxDe43HJt9Bzr9zOFG3maYsL0k1ca3e1c20Ene7DzE0kTb9w75KVteVjpEgEZmlA==", "f918f039-d870-4040-af2f-75dca898d8fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2003, 4, 26, 0, 16, 12, 104, DateTimeKind.Local).AddTicks(664), "b2297909-5100-4205-8579-1befe3908ac7", "ADMIN2@GMAIL.COM", "AQAAAAEAACcQAAAAEJgYFzTbzdo8o3T3kCEYYRiAw95I4irocjr7HoERbiL0hLsHqgyaOzhfpewzpvttkg==", "e78dca85-ba10-4083-af36-1fc058737474" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CustClassId", "ProductDescription", "ProductImage", "ProductName", "ProductPrice" },
                values: new object[] { 2, "Dress up like your favorite Disney Princess Snow White by wearing this Enchanted Disney Fine Jewelry Sterling Silver and 10K Rose Gold Ring with Diamond Accent and Red Garnet. Evoking the gentle yet stern personality of Disney's first princess, this ring is all about female empowerment. It's the jewel for the independent lady who still loves fashion pretend play but does it in a chic, stylish, and very sophisticated way.", "/products/productImgs/6a33a5ce-c010-419a-99f7-1d6e5ef8d343_06-28-2020_SD_RGO8042_0308_72dpi_600x@2x.webp", "Diamond and Red Garnet Snow White Ring", 2450.0 });
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf498b1b-02a5-456d-ae91-4f13386a5b5d", null, "AQAAAAEAACcQAAAAEOrIT4C1AvpXu820u43yeJhb6gsTZPCqnCG27t+sAJ0FU0fEWXgUPI/sNW5oBC7Rdw==", "322f6487-d51b-4054-acb8-12d8e2768c6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2003, 4, 25, 2, 27, 9, 826, DateTimeKind.Local).AddTicks(4114), "1d3e74b2-b560-40ea-ba43-f4d23093451e", null, "AQAAAAEAACcQAAAAEHzN5gakMp/lVR5yLs5rPL/+uQMNo/g2P9SJmFfn5McOMTWV5NpqqkGIswliKW+XAA==", "668978ac-82b5-426f-a63e-156bb448e9d2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CustClassId", "ProductDescription", "ProductImage", "ProductName", "ProductPrice" },
                values: new object[] { 3, "A mysterious bloom carrying many meanings. The black rose, in this Disney Villain ring, actually stands for rebirth and new beginnings. Get this as a token to honor a major change in your life. A creation from the Enchanted Disney Fine Jewelry Collection, this Maleficent Ring features a thorn-inspired sterling silver band plated in black rhodium.", "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", "Maleficent Rose Ring", 4000.0 });
        }
    }
}
