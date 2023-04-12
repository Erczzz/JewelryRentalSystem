using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class Cart
    {
        public Cart()
        {
        }

        [Key]
        public int CartId { get; set; }
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; } = null!;

        [DisplayName("Quantity")]
        public double ProductQty { get; set; }
        [DisplayName("Rent Duration")]
        public int RentDuration { get; set; }
        public double Total { get; set; }
        public bool ConfirmRent { get; set; } = false;
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;
        public int? TransactionId { get; set; }
        public Transaction? Transaction { get; set; }
    }
}
