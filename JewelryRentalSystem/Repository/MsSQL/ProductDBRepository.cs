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

        public async Task<Product> AddProduct(Product newProduct)
        {
            _JRSDBContext.AddAsync(newProduct);
            await _JRSDBContext.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product> DeleteProduct(int ProductId)
        {
            var product = await GetProductById(ProductId);
            if (product != null)
            {
                _JRSDBContext.Products.Remove(product);
                await _JRSDBContext.SaveChangesAsync();
                return product;
            }
            return null;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _JRSDBContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductById(int ProductId)
        {
            return await _JRSDBContext.Products.AsNoTracking().SingleOrDefaultAsync(x => x.ProductId == ProductId);
        }

        public async Task<Product> UpdateProduct(int ProductId, Product newProduct)
        {
             _JRSDBContext.Products.Update(newProduct);
            await _JRSDBContext.SaveChangesAsync();
            return newProduct;
        }
    }
}
