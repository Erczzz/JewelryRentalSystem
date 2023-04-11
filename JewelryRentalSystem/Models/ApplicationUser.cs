using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Birth of Date")]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
        [DisplayName("Contact Number")]
        [MinLength(11)]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        public string ContactNo { get; set; }
        public string Address { get; set; }

        public ICollection<Cart> Carts {get; set; } = new List<Cart>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
