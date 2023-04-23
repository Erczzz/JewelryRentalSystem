using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystemAPI.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        [DisplayName("Location")]
        public string LocationName { get; set; }
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
