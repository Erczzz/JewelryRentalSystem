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

        //public bool CreateProduct(int categoryId, Product newProduct)
        //{
        //    var category = _context.Categories.Where(a => a.CategoryId == categoryId).FirstOrDefault();
        //    var newProd = new Product
        //    {
        //        CategoryId = categoryId,
        //    };
        //    _context.Products.Add(newProduct);
        //    return Save();
        //}

        public Product GetProductById(int prodId)
        {
            return _context.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.Where(p => p.ProductName == name).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
