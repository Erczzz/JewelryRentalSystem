using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data.EntityRelationship
{
    public static class ProductCategory
    {
        public static void ProductCategoryRelation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne<Category>(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
