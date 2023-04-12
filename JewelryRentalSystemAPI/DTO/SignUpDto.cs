using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace JewelryRentalSystemAPI.DTO
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [MinLength(11)]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
