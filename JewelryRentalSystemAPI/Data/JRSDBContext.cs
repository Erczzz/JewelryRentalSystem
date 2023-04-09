using JewelryRentalSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystemAPI.Data
{
    public class JRSDBContext : DbContext
    {
        public JRSDBContext(DbContextOptions<JRSDBContext> options) : base(options) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            var ring = new Category
            {
                CategoryId = 1,
                CategoryName = "Ring",
            };

            var necklace = new Category
            {
                CategoryId = 2,
                CategoryName = "Necklace"
            };

            modelBuilder.Entity<Category>()
                .HasData(ring, necklace);

            var product1 = new Product 
            {
                ProductId = 1,
                ProductName = "Diamond Ring",
                ProductDescription = "Test",
                ProductPrice = 20000,
                ProductStock = 2,
                ProductImage = "Test",
                CategoryId = 1,
            };

            var product2 = new Product
            {
                ProductId = 2,
                ProductName = "Pearl Necklace",
                ProductDescription = "Test",
                ProductPrice = 15000,
                ProductStock = 1,
                ProductImage = "Test",
                CategoryId = 2,
            };
            modelBuilder.Entity<Product>()
                .HasData(product1, product2);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
