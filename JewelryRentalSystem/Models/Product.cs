
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystem.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; } = default!;
        [Required]
        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }
        [Required]
        [DisplayName("Product Stock")]
        public int ProductStock { get; set; }
        [Required]
        public string ProductImage { get; set; } = default!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public Product() { }

        public Product(int productId, string productName, string? productDescription, double productPrice, int productStock, string? productImage, int categoryId)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductStock = productStock;
            ProductImage = productImage;
            CategoryId = categoryId;
        }
    }
}
