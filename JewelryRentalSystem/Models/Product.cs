
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystem.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; } = default!;
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Stock")]
        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than or equal to 0")]
        public int ProductStock { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string ProductImage { get; set; } = default!;
        [Required(ErrorMessage = "This field is required.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int? CustClassId { get; set; }
        public CustomerClassification? CustomerClassification { get; set; }
        public Product() { }

        public Product(int productId, string productName, string? productDescription, double productPrice, 
            int productStock, string? productImage, int categoryId, int? custClassId)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductStock = productStock;
            ProductImage = productImage;
            CategoryId = categoryId;
            CustClassId = custClassId; 
        }
    }
}
