using JewelryRentalSystemAPI.Data;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JRSDBContext _context;

        public CategoryRepository(JRSDBContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Where(e => e.CategoryId == categoryId).FirstOrDefault();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return _context.Products.Where(e => e.CategoryId == categoryId).ToList();
        }
    }
}
