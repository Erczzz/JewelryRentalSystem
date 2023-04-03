using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using JewelryRentalSystem.Models;

namespace JewelryRentalSystem.ViewModels;

public class UserFormModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Birthdate { get; set; }
    [Required]
    [DisplayName("Contact Number")]
    [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
    public string ContactNo { get; set; }
    [Required]
    [EmailAddress]
    [DisplayName("Email Address")]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and confirm password doesnt match")]
    public string ConfirmPassword { get; set; }
    public int RoleId { get; set; }
}

public class CreateUserViewModel
{
    public UserFormModel NewUser { get; set; } = new UserFormModel();
    public List<Role> Roles = new();
}

