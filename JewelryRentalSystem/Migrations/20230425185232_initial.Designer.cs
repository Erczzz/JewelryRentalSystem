﻿// <auto-generated />
using System;
using JewelryRentalSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewelryRentalSystem.Migrations
{
    [DbContext(typeof(JRSDBContext))]
    [Migration("20230425185232_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JewelryRentalSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustClassId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustClassId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            AccessFailedCount = 0,
                            Address = "Sample Address",
                            ConcurrencyStamp = "145ef3d7-adcc-46df-884c-4ee78fb264c9",
                            ContactNo = "09876543211",
                            CustClassId = 5,
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEH3VU/zbVFISJVBXVKF1oVKNpouWvoCpwgIq/lurvJmJRVYaT4oU0cDeguauNjWKGQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7e815b25-e9c8-46c8-9fa0-031aeb176ccc",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com",
                            isActive = true
                        },
                        new
                        {
                            Id = "45e23747-27a5-48e9-b7a6-755bfbb86004",
                            AccessFailedCount = 0,
                            Address = "Sample Address",
                            Birthdate = new DateTime(2003, 4, 26, 2, 52, 31, 991, DateTimeKind.Local).AddTicks(2810),
                            ConcurrencyStamp = "0112c54c-843d-4628-9c7b-49393ee6f016",
                            ContactNo = "09876543211",
                            CustClassId = 5,
                            Email = "admin2@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN2@GMAIL.COM",
                            NormalizedUserName = "ADMIN2@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEF034IpwTHLTkw5LjYLMdp0etVdlwv8mlGlQ/XnPPt4TyPbDpWewR8AQefEk8tEuaA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "24714400-fd4f-40fc-ac1e-507fb03a07f5",
                            TwoFactorEnabled = false,
                            UserName = "admin2@gmail.com",
                            isActive = true
                        });
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"), 1L, 1);

                    b.Property<int>("AppointmentTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("ConfirmAppointment")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateOfAppointment")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleTimeId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AppointmentTypeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ScheduleTimeId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.AppointmentType", b =>
                {
                    b.Property<int>("AppointmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentTypeId"), 1L, 1);

                    b.Property<string>("APTName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentTypeId");

                    b.ToTable("AppointmentTypes");

                    b.HasData(
                        new
                        {
                            AppointmentTypeId = 1,
                            APTName = "Pick-Up"
                        });
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<bool>("ConfirmRent")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQty")
                        .HasColumnType("int");

                    b.Property<int>("RentDuration")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TransactionId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Ring"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Necklace"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Bracelet"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Earrings"
                        });
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.CustomerClassification", b =>
                {
                    b.Property<int>("CustomerClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerClassId"), 1L, 1);

                    b.Property<string>("CustomerClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemLimit")
                        .HasColumnType("int");

                    b.Property<int>("RentLimit")
                        .HasColumnType("int");

                    b.HasKey("CustomerClassId");

                    b.ToTable("CustomerClassifications");

                    b.HasData(
                        new
                        {
                            CustomerClassId = 1,
                            CustomerClassName = "Classic",
                            ItemLimit = 5,
                            RentLimit = 1
                        },
                        new
                        {
                            CustomerClassId = 2,
                            CustomerClassName = "Silver",
                            ItemLimit = 10,
                            RentLimit = 5
                        },
                        new
                        {
                            CustomerClassId = 3,
                            CustomerClassName = "Gold",
                            ItemLimit = 20,
                            RentLimit = 10
                        },
                        new
                        {
                            CustomerClassId = 4,
                            CustomerClassName = "Platinum",
                            ItemLimit = 0,
                            RentLimit = 0
                        },
                        new
                        {
                            CustomerClassId = 5,
                            CustomerClassName = "Admin",
                            ItemLimit = 0,
                            RentLimit = 0
                        });
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            LocationName = "Makati City"
                        },
                        new
                        {
                            LocationId = 2,
                            LocationName = "Quezon City"
                        },
                        new
                        {
                            LocationId = 3,
                            LocationName = "Valenzuela City"
                        },
                        new
                        {
                            LocationId = 4,
                            LocationName = "Antipolo City"
                        },
                        new
                        {
                            LocationId = 5,
                            LocationName = "Taguig City"
                        });
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CustClassId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CustClassId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4,
                            CustClassId = 2,
                            ProductDescription = "Add a pop of color and a touch of magical charm to your looks with this pair of Enchanted Disney Fine Jewelry Dangle Earrings. Featuring a 14k rose gold finish, these sterling silver earrings glitter with class and beauty. Glistening Rose De France complement the pure sparkle of 1/10 CTTW of diamonds. With these beautiful earrings, you won't need magic hair that glows when you sing in order to shine.",
                            ProductImage = "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp",
                            ProductName = "Enchanted Disney Fine Jewelry",
                            ProductPrice = 1250.0,
                            ProductStock = 4
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            CustClassId = 2,
                            ProductDescription = "Dress up like your favorite Disney Princess Snow White by wearing this Enchanted Disney Fine Jewelry Sterling Silver and 10K Rose Gold Ring with Diamond Accent and Red Garnet. Evoking the gentle yet stern personality of Disney's first princess, this ring is all about female empowerment. It's the jewel for the independent lady who still loves fashion pretend play but does it in a chic, stylish, and very sophisticated way.",
                            ProductImage = "/products/productImgs/6a33a5ce-c010-419a-99f7-1d6e5ef8d343_06-28-2020_SD_RGO8042_0308_72dpi_600x@2x.webp",
                            ProductName = "Diamond and Red Garnet Snow White Ring",
                            ProductPrice = 2450.0,
                            ProductStock = 5
                        });
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.ScheduleTime", b =>
                {
                    b.Property<int>("TimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeId"), 1L, 1);

                    b.Property<string>("SchedTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeId");

                    b.ToTable("ScheduleTimes");

                    b.HasData(
                        new
                        {
                            TimeId = 1,
                            SchedTime = "8:00:00 - 9:00:00"
                        },
                        new
                        {
                            TimeId = 2,
                            SchedTime = "9:00:00 - 10:00:00"
                        },
                        new
                        {
                            TimeId = 3,
                            SchedTime = "10:00:00 - 11:00:00"
                        },
                        new
                        {
                            TimeId = 4,
                            SchedTime = "11:00:00 - 12:00:00"
                        },
                        new
                        {
                            TimeId = 5,
                            SchedTime = "13:00:00 - 14:00:00"
                        },
                        new
                        {
                            TimeId = 6,
                            SchedTime = "14:00:00 - 15:00:00"
                        },
                        new
                        {
                            TimeId = 7,
                            SchedTime = "15:00:00 - 16:00:00"
                        },
                        new
                        {
                            TimeId = 8,
                            SchedTime = "16:00:00 - 17:00:00"
                        });
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("JewelryRentalSystem.ViewModels.ActivateAccountViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ActivateAccountViewModel");
                });

            modelBuilder.Entity("JewelryRentalSystem.ViewModels.ModifyAccountViewModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthdate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ModifyAccountViewModel");
                });

            modelBuilder.Entity("JewelryRentalSystem.ViewModels.ProfileViewModel", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthdate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemLimit")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentLimit")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("ProfileViewModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9ea94376-bae3-4592-b2ef-16e2222ec6f4",
                            ConcurrencyStamp = "9ea94376-bae3-4592-b2ef-16e2222ec6f4",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "f913644d-d5a1-4c4a-a73b-dacc6a8c7898",
                            ConcurrencyStamp = "f913644d-d5a1-4c4a-a73b-dacc6a8c7898",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            RoleId = "9ea94376-bae3-4592-b2ef-16e2222ec6f4"
                        },
                        new
                        {
                            UserId = "45e23747-27a5-48e9-b7a6-755bfbb86004",
                            RoleId = "9ea94376-bae3-4592-b2ef-16e2222ec6f4"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.ApplicationUser", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.CustomerClassification", "CustomerClassification")
                        .WithMany("Users")
                        .HasForeignKey("CustClassId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CustomerClassification");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Appointment", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.AppointmentType", "AppointmentType")
                        .WithMany()
                        .HasForeignKey("AppointmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryRentalSystem.Models.ApplicationUser", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JewelryRentalSystem.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryRentalSystem.Models.ScheduleTime", "ScheduleTime")
                        .WithMany()
                        .HasForeignKey("ScheduleTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentType");

                    b.Navigation("Customer");

                    b.Navigation("Location");

                    b.Navigation("ScheduleTime");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Cart", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.ApplicationUser", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryRentalSystem.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryRentalSystem.Models.Transaction", "Transaction")
                        .WithMany("Carts")
                        .HasForeignKey("TransactionId");

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Product", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryRentalSystem.Models.CustomerClassification", "CustomerClassification")
                        .WithMany("Products")
                        .HasForeignKey("CustClassId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");

                    b.Navigation("CustomerClassification");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Transaction", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId");

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryRentalSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JewelryRentalSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.ApplicationUser", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Carts");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.CustomerClassification", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JewelryRentalSystem.Models.Transaction", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
