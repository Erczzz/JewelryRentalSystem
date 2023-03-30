using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class User
    {

        public int UserId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        public string ContactNo { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Username { get; set; }

        public int? RoleId { get; set; }
        public Role? Role { get; set; }


        public User() { }
        public User(int userId, string firstName, string lastName, DateTime birthDate, string contactNo, string email, string address, string username, int roleId)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ContactNo = contactNo;
            Email = email;
            Address = address;
            Username = username;

        }
    }
}
