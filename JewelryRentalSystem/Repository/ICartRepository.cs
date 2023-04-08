using JewelryRentalSystem.Models;

namespace JewelryRentalSystem.Repository
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllCarts();
        Task<Cart> GetCartById(int CartId);
        Task<Cart> AddToCart(Cart newCart);
        Task<Cart> UpdateCart(int CartId, Cart newCart);
        Task<Cart> DeleteCart(int CartId);
        Task<List<Product>> GetAllProducts();
    }
}
