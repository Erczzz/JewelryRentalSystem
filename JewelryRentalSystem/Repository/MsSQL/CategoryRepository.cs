using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JRSDBContext _JRSDBContext;
        public CategoryRepository(JRSDBContext jRSDBContext)
        {
            _JRSDBContext = jRSDBContext;
        }
        public async Task<Category> AddCategory(Category newCategory)
        {
            await _JRSDBContext.AddAsync(newCategory);
            await _JRSDBContext.SaveChangesAsync();
            return newCategory;
        }

        public async Task<Category> DeleteCategory(int CategoryId)
        {
            var category = await GetCategoryById(CategoryId);
            if (category != null)
            {
                _JRSDBContext.Categories.Remove(category);
                await _JRSDBContext.SaveChangesAsync();
                return category;
            }
            return null;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _JRSDBContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _JRSDBContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            return await _JRSDBContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.CategoryId == CategoryId);
        }

        public async Task<Category> UpdateCategory(int CategoryId, Category newCategory)
        {
            _JRSDBContext.Categories.Update(newCategory);
            await _JRSDBContext.SaveChangesAsync();
            return newCategory;
        }
    }
}
