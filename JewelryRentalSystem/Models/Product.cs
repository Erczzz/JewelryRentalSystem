using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        // public string ProductImage { get; set; }
        public int ProductStock { get; set; }
        public string? ProductImage { get; set; }
       
/*        public string ProdPhotoPath { get; set; }
        public string ProdFileName { get; set; }
        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }*/
        public Product() { }

        public Product(int productId, string productName, string productDescription, double productPrice, int productStock)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductStock = productStock;
        }
    }
}
