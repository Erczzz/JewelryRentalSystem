
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

        [DisplayName("Image")]
        public string? ProductImage { get; set; }
        
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        

    }
}
