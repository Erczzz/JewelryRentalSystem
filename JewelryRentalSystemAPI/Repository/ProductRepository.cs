using JewelryRentalSystemAPI.Data;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Repository
{
    public class ProductRepository : IProductRepository
    { 
        private readonly JRSDBContext _context;
        public ProductRepository(JRSDBContext context) 
        {
            _context = context;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.Where(p => p.ProductName == name).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }

    }
}
