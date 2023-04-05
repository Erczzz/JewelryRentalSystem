using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double ProductQty { get; set; }
        public double TransactionTotal { get; set; }
    }
}
