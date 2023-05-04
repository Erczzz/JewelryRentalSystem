using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class ProductDBRepository : IProductDBRepository
    {
        private readonly JRSDBContext _JRSDBContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductDBRepository(JRSDBContext jRSDBContext, IWebHostEnvironment webHostEnvironment)
        {
            _JRSDBContext = jRSDBContext;
            _webHostEnvironment = webHostEnvironment;
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

        /*public async Task<Product> UpdateProduct(int ProductId, Product newProduct)
        {
             _JRSDBContext.Products.Update(newProduct);
            await _JRSDBContext.SaveChangesAsync();
            return newProduct;
        }*/
        public async Task<Product> UpdateProduct(Product updatedProduct, IFormFile image)
        {
            var product = await _JRSDBContext.Products.FindAsync(updatedProduct.ProductId);

            if (product != null)
            {
                product.ProductId = updatedProduct.ProductId;
                product.ProductName = updatedProduct.ProductName;
                product.ProductDescription = updatedProduct.ProductDescription;
                product.ProductPrice = updatedProduct.ProductPrice;
                product.ProductStock = updatedProduct.ProductStock;
                product.CategoryId = updatedProduct.CategoryId;
                product.CustomerClassification = updatedProduct.CustomerClassification;

                if (image != null)
                {
                    // Save the new image file
                    // You can customize this code to store the image in a different location or with a different name
                    string folder = "products/productImgs/";
                    folder += Guid.NewGuid().ToString() + "_" + image.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    image.CopyTo(new FileStream(serverFolder, FileMode.Create));


                    product.ProductImage = "/" + folder;
                }
                else
                {
                    // If model.ProductImage is null, keep the existing product image
                    product.ProductImage = product.ProductImage;
                }


                // Save changes to the database
                _JRSDBContext.Entry(product).State = EntityState.Modified;
                await _JRSDBContext.SaveChangesAsync();
            }

            return product;
        }

        public async Task<Product> AddToCart(int ProductId)
        {
            return await _JRSDBContext.Products.AsNoTracking().SingleOrDefaultAsync(x => x.ProductId == ProductId);
        }

    }
    
}
