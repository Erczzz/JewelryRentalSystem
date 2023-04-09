using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Interface
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void AssignNewCategory(int productId, int categoryId);
        Product GetProductById(int prodId);
        Product GetProductByName(string name);

    }
}
