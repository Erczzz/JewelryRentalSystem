using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JewelryRentalSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date")]
        public DateTime DateOfAppointment { get; set; }
        [DisplayName("Time")]
        public int ScheduleTimeId { get; set; }    
        public ScheduleTime ScheduleTime { get; set; } = null!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public int AppointmentTypeId { get; set; }
        public AppointmentType AppointmentType { get; set; } = null!;
        public Appointment() { }

    }
}
