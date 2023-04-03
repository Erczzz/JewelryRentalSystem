using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
