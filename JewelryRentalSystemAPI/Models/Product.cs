using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JewelryRentalSystemAPI.Models
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
        public string? ProductDescription { get; set; }
        [Required]
        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }
        [Required]
        [DisplayName("Product Stock")]
        public int ProductStock { get; set; }
    }
}
