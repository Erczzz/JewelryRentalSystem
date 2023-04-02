using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class ProductDBRepository : IProductDBRepository
    {
        private readonly JRSDBContext _JRSDBContext;
        public ProductDBRepository(JRSDBContext jRSDBContext)
        {
            _JRSDBContext = jRSDBContext;
        }

        public Product AddProduct(Product newProduct)
        {
            _JRSDBContext.Add(newProduct);
            _JRSDBContext.SaveChanges();
            return newProduct;
        }

        public Product DeleteProduct(int ProductId)
        {
            var product = GetProductById(ProductId);
            if (product != null)
            {
                _JRSDBContext.Products.Remove(product);
                _JRSDBContext.SaveChanges();
            }
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _JRSDBContext.Products.AsNoTracking().ToList();
        }

        public Product GetProductById(int ProductId)
        {
            return _JRSDBContext.Products.AsNoTracking().ToList().FirstOrDefault(x => x.ProductId == ProductId);
        }

        public Product UpdateProduct(int ProductId, Product newProduct)
        {
            _JRSDBContext.Products.Update(newProduct);
            _JRSDBContext.SaveChanges();
            return newProduct;
        }
    }
}
