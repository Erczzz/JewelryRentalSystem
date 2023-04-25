using JewelryRentalSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data
{
    public static class SeedData
    {
        public static void SeedAdminUser(this ModelBuilder modelBuilder)
        {
            var admin_RoleId = "9ea94376-bae3-4592-b2ef-16e2222ec6f4";
            var cust_RoleId = "f913644d-d5a1-4c4a-a73b-dacc6a8c7898";
            string user_AdminId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string user_AdminId2 = "45e23747-27a5-48e9-b7a6-755bfbb86004";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {

                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = admin_RoleId,
                ConcurrencyStamp = admin_RoleId
            },
            new IdentityRole
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                Id = cust_RoleId,
                ConcurrencyStamp = cust_RoleId
            }
            );

            var user = new ApplicationUser
            {
                Id = user_AdminId,
                Email = "admin@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@gmail.com",
                ContactNo = "09876543211",
                Address = "Sample Address",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                CustClassId = 5
            };

            var user2 = new ApplicationUser
            {
                Id = user_AdminId2,
                Email = "admin2@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                Birthdate = DateTime.Now.AddYears(-20),
                UserName = "admin2@gmail.com",
                ContactNo = "09876543211",
                Address = "Sample Address",
                NormalizedUserName = "ADMIN2@GMAIL.COM",
                NormalizedEmail = "ADMIN2@GMAIL.COM",
                CustClassId = 5
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "password1!");
            user2.PasswordHash = ph.HashPassword(user2, "Password1!");

            //seed user
            modelBuilder.Entity<ApplicationUser>().HasData(user);
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = admin_RoleId,
                UserId = user_AdminId
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = admin_RoleId,
                UserId = user_AdminId2
            });
        }

        public static void SeedDefaultTime(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleTime>().HasData(
                new ScheduleTime(1, "8:00:00 - 9:00:00"),
                new ScheduleTime(2, "9:00:00 - 10:00:00"),
                new ScheduleTime(3, "10:00:00 - 11:00:00"),
                new ScheduleTime(4, "11:00:00 - 12:00:00"),
                new ScheduleTime(5, "13:00:00 - 14:00:00"),
                new ScheduleTime(6, "14:00:00 - 15:00:00"),
                new ScheduleTime(7, "15:00:00 - 16:00:00"),
                new ScheduleTime(8, "16:00:00 - 17:00:00")
                );

        }

        public static void SeedDefaultProductCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Ring"),
                new Category(2, "Necklace"),
                new Category(3, "Bracelet"),
                new Category(4, "Earrings")
            );
        }

        public static void SeedDefaultProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Enchanted Disney Fine Jewelry",
                "Add a pop of color and a touch of magical charm to your looks with this pair of Enchanted Disney Fine Jewelry Dangle Earrings. Featuring a 14k rose gold finish, these sterling silver earrings glitter with class and beauty. Glistening Rose De France complement the pure sparkle of 1/10 CTTW of diamonds. With these beautiful earrings, you won't need magic hair that glows when you sing in order to shine.",
                1250, 4, "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", 4, 2),
                new Product(2, "Diamond and Red Garnet Snow White Ring",
                "Dress up like your favorite Disney Princess Snow White by wearing this Enchanted Disney Fine Jewelry Sterling Silver and 10K Rose Gold Ring with Diamond Accent and Red Garnet. Evoking the gentle yet stern personality of Disney's first princess, this ring is all about female empowerment. It's the jewel for the independent lady who still loves fashion pretend play but does it in a chic, stylish, and very sophisticated way.",
                2450, 5, "/products/productImgs/6a33a5ce-c010-419a-99f7-1d6e5ef8d343_06-28-2020_SD_RGO8042_0308_72dpi_600x@2x.webp", 1, 2)
/*                new Product(3, "Maleficent Rose Ring",
                "Such a classic pair of earrings but now given a magical twist. These rose-shaped studs with diamond center are crafted from 14k rose gold over sterling silver. They are part of the Enchanted Disney Fine Jewelry Collection and are inspired by Belle. With a design influenced by Belle's character, you'll see these rose earrings to be gentle and delicate yet very much capable of standing and shining on their own.",
                1290, 6, "/products/productImgs/0332f9d5-a488-4011-a5e3-407a7ab96a86_06-11-2020_SD_ERO4580_0265_72dpi_800x.webp", 4, 2),
                new Product(4, "Belle Rose Fashion Ring",
                "The ring that gets a lot of compliments. Why would anyone not notice this beauty? Crafted from 14k rose gold over sterling silver, here is a ring inspired by Belle and exudes her fierce but kind and gentle but strong character. Featuring a bypass shank with sides lined in diamonds and a centerpiece of meeting roses, the interesting design of this ring is meant to start conversations and leave impressions.",
                610, 7, "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", 1, 1),
                new Product(5, "Rose Fashion Pendant Necklace",
                "Celebrate your life that's full of contrast with this heart-shaped pendant inspired by Belle. Part of the Enchanted Disney Fine Jewelry Collection, this sterling silver pendant has its one side simple and the other embellished with diamonds and a 14k rose gold flower accent. Consider this necklace a symbolic accessory that will remind you of the importance of contrasts in order to find balance.",
                735, 3, "/products/productImgs/9a7cf85c-5c57-4571-b1b3-b5a0b9a50ecc_08-16-2018_SD_PDO3592_0003_300dpiNoBezel_600x@2x.webp", 2, 1),
                new Product(6, "Dancing Diamond Rapunzel Pendant Necklace",
                "Rapunzel Collection Style #PDO5187-SP-DS Enchanted Disney Fine Jewelry Sterling Silver with 1/20 CTTW Dancing Diamond Rapunzel Pendant Necklace\r\nA twinkling sun pendant artistically rendered in sterling silver. This piece of fine jewelry is inspired by Rapunzel and is a must-have piece for any Disney fashionista. With this pendant, you not only get to level up your accessorizing but also get to wear a jewelry that's pretty and symbolic. Let this enchanting necklace shaped like the Kingdom of Corona's crest be a beautiful reminder of facing your fears and shining your light.",
                528, 9, "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", 2, 1),
                new Product(7, "Rose-De-France Elsa Snowflake Ring",
                "What a lovely ring this is! The blend of color and sparkle works seamlessly and beautifully without pretension and flaunting. This Enchanted Disney Fine Jewelry Elsa Snowflake Ring is fashioned in 14K Rose Gold over Sterling Silver and displays the radiance of 1/6 carat total weight of diamonds. A Swiss Blue Topaz and a Rose-de-France bring even more grace and sophistication to this sculpted piece of jewelry.",
                2999, 7, "/products/productImgs/e0e7d2b0-dbc8-4744-9dd2-09b53c36c81f_ring2.webp", 1, 3),
                new Product(8, "Wave Ring",
                "Be the voyager princess that you truly are and show great pride for who you are by wearing this Enchanted Disney Fine Jewelry Moana Wave Ring. Fashioned in sterling silver with 1/4 CTTW blue and white diamond, this glittering wave ring will fit your sea-loving, headstrong, and fearless personality. Let it make you stand out from the crowd while keeping you empowered to believe in yourself and stand your ground to fight for what you value.",
                3460, 6, "/products/productImgs/d40ac081-7252-4d38-ae13-43d460359eff_090176_RG11593_0650_client_03_600x@2x.webp", 1, 3),
                new Product(9, "Sun Blaze Earrings",
                "Want a jewelry that tells a story? Get yourself this pair of blazing sun earrings inspired by Rapunzel's tale. These Enchanted Disney Fine Jewelry earrings features a 10 karat yellow gold sunburst stud with a round solitaire diamond at its center. This fashion accessory will not only enhance your sense of style, it can also be a symbolic reminder for you to take a step out of your comfort zone, chase your dreams, and never give up.",
                2910, 3, "/products/productImgs/8ba7413d-c5bb-4d86-b85d-3a8da19d587e_ERO2761Y1WDSZA_600x@2x.webp", 4, 3),
                new Product(10, "Diamond and Green Tourmaline Tinker Bell Star Ring",
                "Acknowledge a loved one's fearless and determined spirit with a Diamond Star Ring present inspired by the feisty fairy, Tinker Bell. This piece of jewelry is crafted from sterling silver and features four sparkling stars. Two twinkles with white diamond beauty and the other two glistens in vivid green tourmaline charm. The whimsical crossover style mirrors the vivacious personality of Tinkerbell and completes the fab fairy charm of this fashion jewelry.",
                1535, 8, "/products/productImgs/6a33a5ce-c010-419a-99f7-1d6e5ef8d343_06-28-2020_SD_RGO8042_0308_72dpi_600x@2x.webp", 1, 2),
                new Product(11, "Fine Jewelry Sterling Silver Earrings",
                "Do you see yourself as somebody who has Tinker Bell's feisty spirit? This pair of whimsical earrings from Enchanted Disney Fine Jewelry is for you. Crafted in sterling silver, shaped into Tinker Bell's iconic pose, and dotted with 1/10 CTTW of diamonds, this pair of earrings will be a lovely addition to your jewelry collection. Wear this whenever you feel like you need a little inspiration to be brave, adventurous, determined, and creative like Tinker Bell.",
                1419, 5, "/products/productImgs/b15d56ed-3e68-4e6f-b0ae-da9e97953104_ERO2574_angle_03_300dpi_600x@2x.webp", 4, 2),
                new Product(12, "Ariel Shell Tiara Ring",
                "You don't have to grow up under the sea to love this sparkling ring. Inspired by the Little Mermaid, this Enchanted Disney Fine Jewelry Sterling Silver and Rose Gold Plating 1/10CTTW Ariel Shell Tiara Ring fits grown-ups who have never lost their childlike wonder. Among your thingamabobs, this one is sure to stand out with its good looks, whimsical charm, and seashell splendor.",
                350, 4, "/products/productImgs/341b9a28-10b7-41af-b959-25a67d2b321b_06-19-2018_SD_RGO7701_0031_72dpi_600x@2x.webp", 1, 1),
                new Product(13, "Medallion Pendant Necklace",
                "A necklace you'll wear year-round. This Enchanted Disney Fine Jewelry 14K Yellow Gold over Sterling Silver with 1/10CTTW Diamonds and Smokey Quartz Pocahontas Medallion Pendant has a versatile aesthetic that will match any look. Aside from adding sparkle to what you wear, this necklace is also ready to bring personality to your style. Channel Pocahontas' free-spirited nature and look and feel confident while marching to the beat of your own drum.",
                290, 7, "/products/productImgs/96b1ec1c-752e-4755-b77f-5146b4d786f0_PDO9307SWYC4SQDJ_600x@2x.webp", 2, 1),
                new Product(14, "Belle Wedding Band",
                "This Enchanted Disney Fine Jewelry Belle Wedding Band is just like how the tale of Beauty and the Beast is both magical and beautiful. Featuring a 14k white gold and rose gold band with a row of brilliant diamonds, this is the ring that will sparkle divinely on your finger. Seal your love with some fairytale charm and let this ring be the dazzling reminder of the promise of a happy ever after.",
                3690, 3, "/products/productImgs/acf14f77-f157-4129-bb94-72c8d1c8263c_31IfSg2Kx1L_600x@2x.webp", 1, 4),
                new Product(15, "Maleficent Rose Pendant Necklace",
                "A floral jewelry to treasure, this Enchanted Disney Fine Jewelry Belle Rose Stud Earrings has a timeless appeal that your beloved will surely appreciate. Crafted in 14k rose gold over sterling, each rose-shaped stud comes with a diamond center. These studs blooming with elegance make for a refreshing statement piece. The size is perfect for daily wear, for day or night outfits. You'd be impressed by how these romantic rose earrings give a chic touch to your looks.",
                400, 5, "/products/productImgs/5ca8ef63-53b6-416c-9d13-75f22dd2592c_earrings2.webp", 1, 1),
                new Product(16, "Diamond Majestic Princess Crown Earrings",
                "Pretty with a touch of whimsy. If you're looking for a gift for a lady who has it all, this pair of Majestic Princess Crown Earrings would be a wonderful choice. It is from the Enchanted Disney Fine Jewelry and is crafted in Sterling Silver decorated with 1/10 carat total weight of diamonds. These earrings can instantly upstyle any outfit and give it a playful yet still sophisticated vibe.",
                411, 5, "/products/productImgs/f97e401a-d915-47e3-90e2-84086332d972_ERO2557-SI3-DSJC_800x.webp", 4, 1),
                new Product(17, "Diamond and London Blue Topaz Ring",
                "Bringing color and sparkle to your fairytale is this Enchanted Disney Fine Jewelry Cinderella Ring. Intricately crafted from sterling silver, its polished shank is dotted with 1/5 CTTW diamonds and neatly topped with a chic London Blue Topaz center stone. This sophisticated band effortlessly exudes beauty, romance and elegance making it the perfect ring for the love of your life who personifies grace and poise.",
                1800, 8, "/products/productImgs/8b35a5bd-9edb-46c5-8dbc-3ff0c4e4bffa_07-18-2018_SD_RGO8220_0046_300dpi_800x.webp", 1, 2),
                new Product(18, "Swiss Blue Topaz Dangling Earrings",
                "Like Elsa, this pair of Enchanted Disney Fine Jewelry Diamonds and Swiss Blue Topaz Dangling Earrings make a statement. They accurately display the character of the Queen of Arendelle - elegant, dramatic, and confident. Exude the same personality by adding these earrings to your wardrobe. Expect this fine piece of jewelry bring an effortless shine and shimmer to whatever you wear.",
                2290, 5, "/products/productImgs/b0066390-209e-4729-8c88-5bf409c7bf5a_06-11-2020_SD_ERO4580_0265_72dpi_800x.webp", 1, 2)*/
                );
        }

        public static void SeedDefaultCustomerClassification(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerClassification>().HasData(
                new CustomerClassification(1, "Classic", 5, 1),
                new CustomerClassification(2, "Silver", 10, 5),
                new CustomerClassification(3, "Gold", 20, 10),
                new CustomerClassification(4, "Platinum", 0, 0),
                new CustomerClassification(5, "Admin", 0, 0)
                );
        }
        public static void SeedDefaultLocation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location(1, "Makati City"),
                new Location(2, "Quezon City"),
                new Location(3, "Valenzuela City"),
                new Location(4, "Antipolo City"),
                new Location(5, "Taguig City")
                );
        }

        public static void SeedDefaultAppointmentType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentType>().HasData(
                new AppointmentType(1, "Pick-Up")
                );
        }

    }
}
