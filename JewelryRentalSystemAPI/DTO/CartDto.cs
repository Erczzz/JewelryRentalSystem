using JewelryRentalSystemAPI.Models;
using System.ComponentModel;

namespace JewelryRentalSystemAPI.DTO
{
    public class CartDto
    {
        public int CartId { get; set; }
        public string CustomerId { get; set; }
        public int ProductQty { get; set; }
        public int RentDuration { get; set; }
        public double Total { get; set; }
        public bool ConfirmRent { get; set; } = false;
        public int ProductId { get; set; }
        public int? TransactionId { get; set; }
    }

}
