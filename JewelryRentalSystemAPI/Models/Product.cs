
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystemAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        
        [DisplayName("Description")]
        public string? ProductDescription { get; set; }
       
        [DisplayName("Price")]
        public double ProductPrice { get; set; }
        
        [DisplayName("Stock")]
        public int ProductStock { get; set; }
        
        public string? ProductImage { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        

    }
}
