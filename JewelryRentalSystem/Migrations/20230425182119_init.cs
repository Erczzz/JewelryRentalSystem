using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AppointmentTypes",
                columns: table => new
                {
                    AppointmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APTName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.AppointmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
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
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ModifyAccountViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifyAccountViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileViewModel",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemLimit = table.Column<int>(type: "int", nullable: false),
                    RentLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViewModel", x => x.CustomerId);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CustClassId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CustomerClassifications_CustClassId",
                        column: x => x.CustClassId,
                        principalTable: "CustomerClassifications",
                        principalColumn: "CustomerClassId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductStock = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CustomerClassifications_CustClassId",
                        column: x => x.CustClassId,
                        principalTable: "CustomerClassifications",
                        principalColumn: "CustomerClassId");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfAppointment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleTimeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    AppointmentTypeId = table.Column<int>(type: "int", nullable: false),
                    ConfirmAppointment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                        column: x => x.AppointmentTypeId,
                        principalTable: "AppointmentTypes",
                        principalColumn: "AppointmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_ScheduleTimes_ScheduleTimeId",
                        column: x => x.ScheduleTimeId,
                        principalTable: "ScheduleTimes",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    RentDuration = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ConfirmRent = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId");
                });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "AppointmentTypeId", "APTName" },
                values: new object[] { 1, "Pick-Up" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "Administrator", "ADMINISTRATOR" },
                    { "f913644d-d5a1-4c4a-a73b-dacc6a8c7898", "f913644d-d5a1-4c4a-a73b-dacc6a8c7898", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Ring" },
                    { 2, "Necklace" },
                    { 3, "Bracelet" },
                    { 4, "Earrings" }
                });

            migrationBuilder.InsertData(
                table: "CustomerClassifications",
                columns: new[] { "CustomerClassId", "CustomerClassName", "ItemLimit", "RentLimit" },
                values: new object[,]
                {
                    { 1, "Classic", 5, 1 },
                    { 2, "Silver", 10, 5 },
                    { 3, "Gold", 20, 10 },
                    { 4, "Platinum", 0, 0 },
                    { 5, "Admin", 0, 0 }
                });

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

            migrationBuilder.InsertData(
                table: "ScheduleTimes",
                columns: new[] { "TimeId", "SchedTime" },
                values: new object[,]
                {
                    { 1, "8:00:00 - 9:00:00" },
                    { 2, "9:00:00 - 10:00:00" },
                    { 3, "10:00:00 - 11:00:00" },
                    { 4, "11:00:00 - 12:00:00" },
                    { 5, "13:00:00 - 14:00:00" },
                    { 6, "14:00:00 - 15:00:00" },
                    { 7, "15:00:00 - 16:00:00" },
                    { 8, "16:00:00 - 17:00:00" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthdate", "ConcurrencyStamp", "ContactNo", "CustClassId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isActive" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "Sample Address", null, "d2811590-b67a-4936-9251-271fe1b8ab84", "09876543211", 5, "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAECldNdohqcFLWw5vPkE8pQmImaV60RUOw6gWtvyhDXsMoY08VdLP2m5Gg1VOHZId5Q==", null, false, "0e5217cd-68d8-4964-9b3d-519ced9ee70d", false, "admin@gmail.com", true },
                    { "45e23747-27a5-48e9-b7a6-755bfbb86004", 0, "Sample Address", new DateTime(2003, 4, 26, 2, 21, 18, 861, DateTimeKind.Local).AddTicks(252), "c4bc6ba6-7699-4bc6-8bf8-d76d1acc2abb", "09876543211", 5, "admin2@gmail.com", false, "admin", "admin", false, null, "ADMIN2@GMAIL.COM", "ADMIN2@GMAIL.COM", "AQAAAAEAACcQAAAAENyyW5de3BT6tpiKszCEug6XqHLt/wJ4Qxe9UMI7serbpQkyPrwwsWVbxs9AJ4vpuQ==", null, false, "abc6c47b-8e67-4b64-9f17-907833fdb671", false, "admin2@gmail.com", true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CustClassId", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "ProductStock" },
                values: new object[,]
                {
                    { 1, 4, 2, "Add a pop of color and a touch of magical charm to your looks with this pair of Enchanted Disney Fine Jewelry Dangle Earrings. Featuring a 14k rose gold finish, these sterling silver earrings glitter with class and beauty. Glistening Rose De France complement the pure sparkle of 1/10 CTTW of diamonds. With these beautiful earrings, you won't need magic hair that glows when you sing in order to shine.", "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", "Enchanted Disney Fine Jewelry", 1250.0, 4 },
                    { 2, 1, 2, "Dress up like your favorite Disney Princess Snow White by wearing this Enchanted Disney Fine Jewelry Sterling Silver and 10K Rose Gold Ring with Diamond Accent and Red Garnet. Evoking the gentle yet stern personality of Disney's first princess, this ring is all about female empowerment. It's the jewel for the independent lady who still loves fashion pretend play but does it in a chic, stylish, and very sophisticated way.", "/products/productImgs/6a33a5ce-c010-419a-99f7-1d6e5ef8d343_06-28-2020_SD_RGO8042_0308_72dpi_600x@2x.webp", "Diamond and Red Garnet Snow White Ring", 2450.0, 5 },
                    { 3, 4, 2, "Such a classic pair of earrings but now given a magical twist. These rose-shaped studs with diamond center are crafted from 14k rose gold over sterling silver. They are part of the Enchanted Disney Fine Jewelry Collection and are inspired by Belle. With a design influenced by Belle's character, you'll see these rose earrings to be gentle and delicate yet very much capable of standing and shining on their own.", "/products/productImgs/0332f9d5-a488-4011-a5e3-407a7ab96a86_06-11-2020_SD_ERO4580_0265_72dpi_800x.webp", "Maleficent Rose Ring", 1290.0, 6 },
                    { 4, 1, 1, "The ring that gets a lot of compliments. Why would anyone not notice this beauty? Crafted from 14k rose gold over sterling silver, here is a ring inspired by Belle and exudes her fierce but kind and gentle but strong character. Featuring a bypass shank with sides lined in diamonds and a centerpiece of meeting roses, the interesting design of this ring is meant to start conversations and leave impressions.", "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", "Belle Rose Fashion Ring", 610.0, 7 },
                    { 5, 2, 1, "Celebrate your life that's full of contrast with this heart-shaped pendant inspired by Belle. Part of the Enchanted Disney Fine Jewelry Collection, this sterling silver pendant has its one side simple and the other embellished with diamonds and a 14k rose gold flower accent. Consider this necklace a symbolic accessory that will remind you of the importance of contrasts in order to find balance.", "/products/productImgs/9a7cf85c-5c57-4571-b1b3-b5a0b9a50ecc_08-16-2018_SD_PDO3592_0003_300dpiNoBezel_600x@2x.webp", "Rose Fashion Pendant Necklace", 735.0, 3 },
                    { 6, 2, 1, "Rapunzel Collection Style #PDO5187-SP-DS Enchanted Disney Fine Jewelry Sterling Silver with 1/20 CTTW Dancing Diamond Rapunzel Pendant Necklace\r\nA twinkling sun pendant artistically rendered in sterling silver. This piece of fine jewelry is inspired by Rapunzel and is a must-have piece for any Disney fashionista. With this pendant, you not only get to level up your accessorizing but also get to wear a jewelry that's pretty and symbolic. Let this enchanting necklace shaped like the Kingdom of Corona's crest be a beautiful reminder of facing your fears and shining your light.", "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", "Dancing Diamond Rapunzel Pendant Necklace", 528.0, 9 },
                    { 7, 1, 3, "What a lovely ring this is! The blend of color and sparkle works seamlessly and beautifully without pretension and flaunting. This Enchanted Disney Fine Jewelry Elsa Snowflake Ring is fashioned in 14K Rose Gold over Sterling Silver and displays the radiance of 1/6 carat total weight of diamonds. A Swiss Blue Topaz and a Rose-de-France bring even more grace and sophistication to this sculpted piece of jewelry.", "/products/productImgs/e0e7d2b0-dbc8-4744-9dd2-09b53c36c81f_ring2.webp", "Rose-De-France Elsa Snowflake Ring", 2999.0, 7 },
                    { 8, 1, 3, "Be the voyager princess that you truly are and show great pride for who you are by wearing this Enchanted Disney Fine Jewelry Moana Wave Ring. Fashioned in sterling silver with 1/4 CTTW blue and white diamond, this glittering wave ring will fit your sea-loving, headstrong, and fearless personality. Let it make you stand out from the crowd while keeping you empowered to believe in yourself and stand your ground to fight for what you value.", "/products/productImgs/d40ac081-7252-4d38-ae13-43d460359eff_090176_RG11593_0650_client_03_600x@2x.webp", "Wave Ring", 3460.0, 6 },
                    { 9, 4, 3, "Want a jewelry that tells a story? Get yourself this pair of blazing sun earrings inspired by Rapunzel's tale. These Enchanted Disney Fine Jewelry earrings features a 10 karat yellow gold sunburst stud with a round solitaire diamond at its center. This fashion accessory will not only enhance your sense of style, it can also be a symbolic reminder for you to take a step out of your comfort zone, chase your dreams, and never give up.", "/products/productImgs/8ba7413d-c5bb-4d86-b85d-3a8da19d587e_ERO2761Y1WDSZA_600x@2x.webp", "Sun Blaze Earrings", 2910.0, 3 },
                    { 10, 1, 2, "Acknowledge a loved one's fearless and determined spirit with a Diamond Star Ring present inspired by the feisty fairy, Tinker Bell. This piece of jewelry is crafted from sterling silver and features four sparkling stars. Two twinkles with white diamond beauty and the other two glistens in vivid green tourmaline charm. The whimsical crossover style mirrors the vivacious personality of Tinkerbell and completes the fab fairy charm of this fashion jewelry.", "/products/productImgs/6a33a5ce-c010-419a-99f7-1d6e5ef8d343_06-28-2020_SD_RGO8042_0308_72dpi_600x@2x.webp", "Diamond and Green Tourmaline Tinker Bell Star Ring", 1535.0, 8 },
                    { 11, 4, 2, "Do you see yourself as somebody who has Tinker Bell's feisty spirit? This pair of whimsical earrings from Enchanted Disney Fine Jewelry is for you. Crafted in sterling silver, shaped into Tinker Bell's iconic pose, and dotted with 1/10 CTTW of diamonds, this pair of earrings will be a lovely addition to your jewelry collection. Wear this whenever you feel like you need a little inspiration to be brave, adventurous, determined, and creative like Tinker Bell.", "/products/productImgs/b15d56ed-3e68-4e6f-b0ae-da9e97953104_ERO2574_angle_03_300dpi_600x@2x.webp", "Fine Jewelry Sterling Silver Earrings", 1419.0, 5 },
                    { 12, 1, 1, "You don't have to grow up under the sea to love this sparkling ring. Inspired by the Little Mermaid, this Enchanted Disney Fine Jewelry Sterling Silver and Rose Gold Plating 1/10CTTW Ariel Shell Tiara Ring fits grown-ups who have never lost their childlike wonder. Among your thingamabobs, this one is sure to stand out with its good looks, whimsical charm, and seashell splendor.", "/products/productImgs/341b9a28-10b7-41af-b959-25a67d2b321b_06-19-2018_SD_RGO7701_0031_72dpi_600x@2x.webp", "Ariel Shell Tiara Ring", 350.0, 4 },
                    { 13, 2, 1, "A necklace you'll wear year-round. This Enchanted Disney Fine Jewelry 14K Yellow Gold over Sterling Silver with 1/10CTTW Diamonds and Smokey Quartz Pocahontas Medallion Pendant has a versatile aesthetic that will match any look. Aside from adding sparkle to what you wear, this necklace is also ready to bring personality to your style. Channel Pocahontas' free-spirited nature and look and feel confident while marching to the beat of your own drum.", "/products/productImgs/96b1ec1c-752e-4755-b77f-5146b4d786f0_PDO9307SWYC4SQDJ_600x@2x.webp", "Medallion Pendant Necklace", 290.0, 7 },
                    { 14, 1, 4, "This Enchanted Disney Fine Jewelry Belle Wedding Band is just like how the tale of Beauty and the Beast is both magical and beautiful. Featuring a 14k white gold and rose gold band with a row of brilliant diamonds, this is the ring that will sparkle divinely on your finger. Seal your love with some fairytale charm and let this ring be the dazzling reminder of the promise of a happy ever after.", "/products/productImgs/acf14f77-f157-4129-bb94-72c8d1c8263c_31IfSg2Kx1L_600x@2x.webp", "Belle Wedding Band", 3690.0, 3 },
                    { 15, 1, 1, "A floral jewelry to treasure, this Enchanted Disney Fine Jewelry Belle Rose Stud Earrings has a timeless appeal that your beloved will surely appreciate. Crafted in 14k rose gold over sterling, each rose-shaped stud comes with a diamond center. These studs blooming with elegance make for a refreshing statement piece. The size is perfect for daily wear, for day or night outfits. You'd be impressed by how these romantic rose earrings give a chic touch to your looks.", "/products/productImgs/5ca8ef63-53b6-416c-9d13-75f22dd2592c_earrings2.webp", "Maleficent Rose Pendant Necklace", 400.0, 5 },
                    { 16, 4, 1, "Pretty with a touch of whimsy. If you're looking for a gift for a lady who has it all, this pair of Majestic Princess Crown Earrings would be a wonderful choice. It is from the Enchanted Disney Fine Jewelry and is crafted in Sterling Silver decorated with 1/10 carat total weight of diamonds. These earrings can instantly upstyle any outfit and give it a playful yet still sophisticated vibe.", "/products/productImgs/f97e401a-d915-47e3-90e2-84086332d972_ERO2557-SI3-DSJC_800x.webp", "Diamond Majestic Princess Crown Earrings", 411.0, 5 },
                    { 17, 1, 2, "Bringing color and sparkle to your fairytale is this Enchanted Disney Fine Jewelry Cinderella Ring. Intricately crafted from sterling silver, its polished shank is dotted with 1/5 CTTW diamonds and neatly topped with a chic London Blue Topaz center stone. This sophisticated band effortlessly exudes beauty, romance and elegance making it the perfect ring for the love of your life who personifies grace and poise.", "/products/productImgs/8b35a5bd-9edb-46c5-8dbc-3ff0c4e4bffa_07-18-2018_SD_RGO8220_0046_300dpi_800x.webp", "Diamond and London Blue Topaz Ring", 1800.0, 8 },
                    { 18, 1, 2, "Like Elsa, this pair of Enchanted Disney Fine Jewelry Diamonds and Swiss Blue Topaz Dangling Earrings make a statement. They accurately display the character of the Queen of Arendelle - elegant, dramatic, and confident. Exude the same personality by adding these earrings to your wardrobe. Expect this fine piece of jewelry bring an effortless shine and shimmer to whatever you wear.", "/products/productImgs/b0066390-209e-4729-8c88-5bf409c7bf5a_06-11-2020_SD_ERO4580_0265_72dpi_800x.webp", "Swiss Blue Topaz Dangling Earrings", 2290.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ea94376-bae3-4592-b2ef-16e2222ec6f4", "45e23747-27a5-48e9-b7a6-755bfbb86004" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ScheduleTimeId",
                table: "Appointments",
                column: "ScheduleTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustClassId",
                table: "AspNetUsers",
                column: "CustClassId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_TransactionId",
                table: "Carts",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustClassId",
                table: "Products",
                column: "CustClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AppointmentId",
                table: "Transactions",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivateAccountViewModel");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ModifyAccountViewModel");

            migrationBuilder.DropTable(
                name: "ProfileViewModel");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ScheduleTimes");

            migrationBuilder.DropTable(
                name: "CustomerClassifications");
        }
    }
}
