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

        public Product GetProductByName(string name)
        {
            return _context.Products.Where(p => p.ProductName == name).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }

        public Product DeleteProduct(int productId)
        {
            var product =  GetProductById(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        public Product AddProduct(Product newProduct)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return newProduct;  
        }

        public Product UpdateProduct(int productId, Product newProduct)
        {
            var products = _context.Products.Find(productId);
            if (products is null)
            {
                throw new Exception("Trying to update product that doesn't exists.");
            }

            products.ProductName = newProduct.ProductName;
            products.ProductDescription = newProduct.ProductDescription;
            products.ProductPrice = newProduct.ProductPrice;
            products.ProductStock = newProduct.ProductStock;
            products.ProductImage = newProduct.ProductImage;
            products.CategoryId = newProduct.CategoryId;

            _context.Products.Update(products);
            _context.SaveChanges();
            return products;
        }
    }
}
