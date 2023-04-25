using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class ModifyAccountViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Please enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [MinLength(11, ErrorMessage = "The minimum length should be 11 digits")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid Email Address")]
        public string Email { get; set; }
    }
}
