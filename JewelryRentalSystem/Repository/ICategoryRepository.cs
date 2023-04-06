using JewelryRentalSystem.Models;

namespace JewelryRentalSystem.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int CategoryId);
        Task<Category> AddCategory(Category newCategory);
        Task<Category> UpdateCategory(int CategoryId, Category newCategory);
        Task<Category> DeleteCategory(int CategoryId);
        Task<List<Product>> GetAllProducts();
    }
}
