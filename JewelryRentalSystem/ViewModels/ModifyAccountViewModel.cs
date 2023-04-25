using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class ModifyAccountViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Please enter your First Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "This field allows letters only.")]
        public string FirstName { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "This field allows letters only.")]

        [Required(ErrorMessage = "Please enter your Last Name")]
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

    public class DateEssThanOrEqualToTodayAttribute : ValidationAttribute
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

            if (date.Date < DateTime.UtcNow.Date)
            {
                return new ValidationResult("Invalid input. Please enter correct birthdate.");
            }

            return ValidationResult.Success;
        }
    }
}
