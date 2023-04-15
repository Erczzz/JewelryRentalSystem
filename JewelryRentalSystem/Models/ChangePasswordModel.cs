
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="Current Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New Password is required."), DataType(DataType.Password), Display(Name = "New Password")]
        [MinLength(5, ErrorMessage = "Minimun length must be 5.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required."), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Confirm new password does not match")]
        [MinLength(5, ErrorMessage = "Minimun length must be 5.")]
        public string ConfirmPassword { get; set;}
    }
}
