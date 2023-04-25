namespace JewelryRentalSystem.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public Transaction()
        {
            
        }

    }
}
