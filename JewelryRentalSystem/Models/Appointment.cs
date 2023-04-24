using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JewelryRentalSystem.Models
{
    public class Appointment
    {
        private static readonly DateTime MinDate = DateTime.UtcNow.Date;

        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string? CustomerId { get; set; }
        public ApplicationUser? Customer { get; set; }
        [Required(ErrorMessage = "Date field is required.")]
        [DataType(DataType.Date)]
        [DateGreaterThanOrEqualToToday(ErrorMessage = "Date must be equal or greater than today's date.")]
        [DisplayName("Date")]
        public DateTime? DateOfAppointment { get; set; }
        [DisplayName("Time")]
        public int ScheduleTimeId { get; set; }    
        public ScheduleTime? ScheduleTime { get; set; } = null!;
        public int LocationId { get; set; }
        public Location? Location { get; set; } = null!;
        public int AppointmentTypeId { get; set; }
        public AppointmentType? AppointmentType { get; set; } = null!;
        public bool ConfirmAppointment { get; set; } = false;
        public Appointment() { }

    }
    public class DateGreaterThanOrEqualToTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Date is required.");
            }

            DateTime date;
            bool parsed = DateTime.TryParse(value.ToString(), out date);
            if (!parsed)
            {
                return new ValidationResult("Invalid date format.");
            }

            if (date.Date < DateTime.UtcNow.Date)
            {
                return new ValidationResult("Invalid input. Please enter correct appointment date.");
            }

            return ValidationResult.Success;
        }
    }

}
