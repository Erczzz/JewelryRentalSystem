using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Interface
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int prodId);
        Product GetProductByName(string name);
        /*bool CreateProduct (int categoryId, Product newProduct);*/
        bool Save();
    }
}
