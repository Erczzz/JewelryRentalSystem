using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Interface
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product GetProductById(int id);
        Product GetProductByName(string name);

    }
}
