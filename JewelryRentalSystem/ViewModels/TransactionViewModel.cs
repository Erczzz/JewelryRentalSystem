using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class TransactionViewModel
    {
        [Key]
        public int TransactionId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Appointment")]
        public DateTime AppointmentDate { get; set; }
        [DisplayName("Time of Appointment")]
        public string AppointmentTime { get; set; }
        [DisplayName("Branch Location")]
        public string Location { get; set; }

    }
}
