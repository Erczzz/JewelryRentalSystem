using JewelryRentalSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class CartViewModel
    {
        [Key]
        public int CartId { get; set; }
        public string CustomerId { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        public double ProductQty { get; set; }
        [Required]
        [DisplayName("Rent Duration")]
        public int RentDuration { get; set; }
        [Required]
        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }
        public string ProductImage { get; set; } = default!;
    }

}
