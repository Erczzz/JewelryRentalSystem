using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Qty")]
        public double ProductQty { get; set; }
        [Required]
        [DisplayName("Rent Duration")]
        public int RentDuration { get; set; }
        [Required]
        [DisplayName("Price")]
        public double ProductPrice { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }
    }
}
