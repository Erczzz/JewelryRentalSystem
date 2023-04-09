using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JewelryRentalSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date")]
        public DateTime DateOfAppointment { get; set; }
        [DisplayName("Time")]
        public string TimeOfAppointment { get; set; }
        [DisplayName("Total Amount")]
        public double TotalAmountToBePaid { get; set; }
        public int? TimeId { get; set; }      
        public int? LocationId { get; set; }
        public ScheduleTime? ScheduleTime { get; set; }
        public Location? Location { get; set; }
        public Appointment() { }

        public Appointment(int appointmentId, string customerName, 
            DateTime dateOfAppointment, string timeOfAppointment, 
            double totalAmountToBePaid, int? timeId, int? locationId)
        {
            AppointmentId = appointmentId;
            CustomerName = customerName;
            DateOfAppointment = dateOfAppointment;
            TimeOfAppointment = timeOfAppointment;
            TotalAmountToBePaid = totalAmountToBePaid;
            TimeId = timeId;
            LocationId = locationId;
        }
    }
}
