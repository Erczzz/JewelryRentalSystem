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
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Where(e => e.CategoryId == categoryId).FirstOrDefault();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return _context.ProductCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Product).ToList();
        }
    }
}
