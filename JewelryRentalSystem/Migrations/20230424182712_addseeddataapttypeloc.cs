using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class addseeddataapttypeloc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "AppointmentTypeId", "APTName" },
                values: new object[] { 1, "Pick-Up" });

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

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { 1, "Makati City" },
                    { 2, "Quezon City" },
                    { 3, "Valenzuela City" },
                    { 4, "Antipolo City" },
                    { 5, "Taguig City" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductPrice",
                value: 1250.0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CustClassId", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "ProductStock" },
                values: new object[] { 2, 1, 3, "A mysterious bloom carrying many meanings. The black rose, in this Disney Villain ring, actually stands for rebirth and new beginnings. Get this as a token to honor a major change in your life. A creation from the Enchanted Disney Fine Jewelry Collection, this Maleficent Ring features a thorn-inspired sterling silver band plated in black rhodium.", "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", "Maleficent Rose Ring", 4000.0, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa828dcd-e1bb-4c71-91aa-e13d858c299a", "AQAAAAEAACcQAAAAEIBCNIQAk3eNV0h+nXInzhZhZhhYMynWYgT/zFwrcJxaYzlYM2Ofx8JRQ+dNQxFyZg==", "edb516e3-3dd0-4759-8ae9-70d6929897e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45e23747-27a5-48e9-b7a6-755bfbb86004",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2003, 4, 25, 1, 22, 40, 784, DateTimeKind.Local).AddTicks(7778), "e66655ff-eda8-49d5-bc37-5a7bc5a7958d", "AQAAAAEAACcQAAAAEJaOhT+callVU0FE5uusmzwxG80BA4B2VjnrnCkpuF4cmgFTc+uxf6SgGjPXTgso5Q==", "85c834db-b364-4a7c-9093-9307062feb33" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductPrice",
                value: 4000.0);
        }
    }
}
