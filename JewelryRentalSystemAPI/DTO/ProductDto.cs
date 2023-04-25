using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystemAPI.DTO
{
    public class ProductDto
    {
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Product Description")]
        public string? ProductDescription { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }

        [Required]
        [DisplayName("Product Stock")]
        public int ProductStock { get; set; }

        [Required]
        [DisplayName("Product Image")]
        public string? ProductImage { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CustClassId")]
        public int? CustClassId { get; set; }
        

        public ProductDto() { }

        public ProductDto(string productName, string productDescription, double productPrice, int productStock, string productImage, int categoryId, int custclassId)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductStock = productStock;
            ProductImage = productImage;
            CategoryId = categoryId;
            CustClassId = custclassId;
        }
    }
}
