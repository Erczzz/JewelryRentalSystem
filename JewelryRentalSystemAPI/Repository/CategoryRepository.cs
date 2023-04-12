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

        public Category AddCategory(Category newCategory)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return newCategory;
        }

        public Category DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return category;
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

        public Category UpdateCategory(int categoryId, Category updatedCategory)
        {
            var categories = _context.Categories.Find(categoryId);
            if (categories is null)
            {
                throw new Exception("Trying to update category that doesn't exists.");
            }

            categories.CategoryName = updatedCategory.CategoryName;

            _context.Categories.Update(categories);
            _context.SaveChanges();
            return categories;
        }
    }
}
