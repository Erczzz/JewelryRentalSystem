using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;

namespace JewelryRentalSystem.Repository
{
    public interface IProductDBRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int ProductId);
        Product AddProduct(Product newProduct);
        Product UpdateProduct(int ProductId, Product newProduct);
        Product DeleteProduct(int ProductId);
    }
}
