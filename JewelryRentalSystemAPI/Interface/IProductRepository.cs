using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Interface
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product GetProductById(int prodId);
        Product GetProductByName(string name);

    }
}
