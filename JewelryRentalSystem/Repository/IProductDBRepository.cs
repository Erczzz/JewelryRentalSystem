using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;

namespace JewelryRentalSystem.Repository
{
    public interface IProductDBRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int ProductId);
        Task<Product> AddProduct(Product newProduct);
        Task<Product> UpdateProduct(Product updatedProduct, IFormFile image);
        Task<Product> DeleteProduct(int ProductId);
        Task<Product> AddToCart(int ProductId);
    }
}
