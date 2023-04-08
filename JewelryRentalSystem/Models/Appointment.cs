using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JewelryRentalSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Appointment")]
        public DateTime DateOfAppointment { get; set; }
        [DisplayName("Time Of Appointment")]
        public string TimeOfAppointment { get; set; }
        [DisplayName("Total Amount To Be Paid")]
        public double TotalAmountToBePaid { get; set; }
        public int? TimeId { get; set; }
        public ScheduleTime? ScheduleTime { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public Appointment() { }

        public Appointment(int appointmentId, DateTime dateOfAppointment, 
            string timeOfAppointment, double totalAmountToBePaid, int? timeId, 
            ScheduleTime? scheduleTime, int? locationId)
        {
            AppointmentId = appointmentId;
            DateOfAppointment = dateOfAppointment;
            TimeOfAppointment = timeOfAppointment;
            TotalAmountToBePaid = totalAmountToBePaid;
            TimeId = timeId;
            ScheduleTime = scheduleTime;
            LocationId = locationId;
        }
    }
}
