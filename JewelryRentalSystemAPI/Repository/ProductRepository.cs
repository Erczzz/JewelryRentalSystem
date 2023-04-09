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

        public Product GetProductById(int prodId)
        {
            return _context.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
        }

        public void AssignNewCategory (int productId, int categoryId)
        {
            var newProductCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };
            _context.ProductCategories.Add(newProductCategory);

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
