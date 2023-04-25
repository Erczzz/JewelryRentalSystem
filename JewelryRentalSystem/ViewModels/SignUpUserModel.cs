using JewelryRentalSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please enter your First Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Birth of Date")]
        [Required(ErrorMessage = "Date field is required.")]
        [DataType(DataType.Date)]
        [DateGreaterThanOrEqualToToday(ErrorMessage = "Date must be equal or greater than today's date.")]
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

        [Required(ErrorMessage = "Please enter a strong password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{5,}$", ErrorMessage = "Password must have a minimum of five characters, at least one letter, one number and one special character")]
        public string Password { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{5,}$", ErrorMessage = "Password must have a minimum of five characters, at least one letter, one number and one special character")]
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public int CustomerClassId { get; set; } = 1;
        public CustomerClassification? CustomerClassification { get; set; }
    }

    public class DateGreaterThanOrEqualToTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date is required.");
            }

            DateTime date;
            bool parsed = DateTime.TryParse(value.ToString(), out date);
            if (!parsed)
            {
                return new ValidationResult("Invalid date format.");
            }

            if (date.Date > DateTime.UtcNow.Date)
            {
                return new ValidationResult("Invalid input. Please enter correct birthdate.");
            }

            return ValidationResult.Success;
        }
    }

}
