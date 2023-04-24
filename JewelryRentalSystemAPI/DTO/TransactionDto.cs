using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.DTO
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int? AppointmentId { get; set; }
        public TransactionDto()
        {
        }

    }
}
