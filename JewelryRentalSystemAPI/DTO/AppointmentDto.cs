using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.DTO
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "Date field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date")]
        public DateTime DateOfAppointment { get; set; } = DateTime.Now;
        [DisplayName("Time")]
        public int ScheduleTimeId { get; set; }
        public int LocationId { get; set; }
        public int AppointmentTypeId { get; set; }
        public bool ConfirmAppointment { get; set; } = false;
        public AppointmentDto() { }

    }
}
