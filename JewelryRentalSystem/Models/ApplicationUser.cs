using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }

        public ICollection<Cart> Carts {get; set; } = new List<Cart>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public bool isActive { get; set; } = true;

        public int? CustClassId { get; set; } = 1;
        public CustomerClassification? CustomerClassification { get; set; }

    }
}
