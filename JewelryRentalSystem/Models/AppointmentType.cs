using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class AppointmentType
    {
        public int AppointmentTypeId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string APTName { get; set;}

        public AppointmentType() { }

        public AppointmentType(int appointmentTypeId, string aPTName)
        {
            AppointmentTypeId = appointmentTypeId;
            APTName = aPTName;
        }
    }
}
