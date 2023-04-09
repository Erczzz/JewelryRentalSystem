using JewelryRentalSystemAPI.Data;
using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI
{
    public class Seed
    {
        private readonly JRSDBContext jRSDBContext;
        public Seed(JRSDBContext context) 
        {
            this.jRSDBContext = context;
        }

        public void SeedJRSDBContext()
        {
            if (!jRSDBContext.ProductCategories.Any())
            {
                var productCategories = new List<ProductCategory>()
                {
                    new ProductCategory()
                    {
                        Product = new Product
                        {
                            ProductId = 1,
                            ProductName = "Diamond Ring",
                            ProductDescription = "Sample Description",
                            ProductPrice = 15000,
                            ProductStock = 2,
                            ProductImage = "Image",
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { CategoryId = 1, CategoryName = "Ring"}}
                            }
                        }
                    },
                    new ProductCategory()
                    {
                        Product = new Product
                        {
                            ProductId = 2,
                            ProductName = "Diamond Necklace",
                            ProductDescription = "Sample Description",
                            ProductPrice = 25000,
                            ProductStock = 3,
                            ProductImage = "Image",
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { CategoryId = 2, CategoryName = "Necklace"}}
                            }
                        }
                    },
                    new ProductCategory()
                    {
                        Product = new Product
                        {
                            ProductId = 3,
                            ProductName = "Diamond Earrings",
                            ProductDescription = "Sample Description",
                            ProductPrice = 10000,
                            ProductStock = 5,
                            ProductImage = "Image",
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { CategoryId = 3, CategoryName = "Earrings"}}
                            }
                        }
                    }
                };
                jRSDBContext.ProductCategories.AddRange(productCategories);
                jRSDBContext.SaveChanges();
            }
        }
    }
}
