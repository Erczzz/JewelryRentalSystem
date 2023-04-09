using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        List<Product> GetProductByCategory(int categoryId);
    }
}
