using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        [DisplayName("Location")]
        public string LocationName { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public Location()
        {
            
        }

        public Location(int locationId, string locationName)
        {
            LocationId = locationId;
            LocationName = locationName;
        }
    }
}
