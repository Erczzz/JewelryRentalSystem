using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JewelryRentalSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Appointment")]
        public DateTime DateOfAppointment { get; set; }
        public string TimeOfAppointment { get; set; }
        public string Location { get; set; }
        public double TotalAmountToBePaid { get; set; }
        public Appointment() { }

        public Appointment(int appointmentId, DateTime dateOfAppointment, string timeOfAppointment, string location, double totalAmountToBePaid)
        {
            AppointmentId = appointmentId;
            DateOfAppointment = dateOfAppointment;
            TimeOfAppointment = timeOfAppointment;
            Location = location;
            TotalAmountToBePaid = totalAmountToBePaid;
        }
    }
}
