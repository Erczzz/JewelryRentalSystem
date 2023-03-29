using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
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
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return _JRSDBContext.Products.AsNoTracking().ToList();
        }

        public Product GetProductById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(int ProductId, Product newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
