using JewelryRentalSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Appointment")]
        public DateTime AppointmentDate { get; set; }
        [DisplayName("Time of Appointment")]
        public string AppointmentTime { get; set; }
        [DisplayName("Branch Location")]
        public string Location { get; set; }
        public List<Cart> Carts { get; set; } = new();
        public List<Appointment> Appointments { get; set; }
        public int AppointmentId { get; set; }

    }
}
