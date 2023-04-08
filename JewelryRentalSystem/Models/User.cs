using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Birth of Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [DisplayName("Contact Number")]
        [MinLength(11)]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        public string ContactNo { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [EmailAddress]       
        public string Email { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public Role? Roles { get; set; }

        public int? CartId { get; set; }
        public Cart? Cart { get; set; }


        //public User() 
        //{ 
        //}

        //public User(int userId, string firstName, string lastName, DateTime birthDate, string contactNo, string email, string address, string username, int roleId)
        //{
        //    UserId = userId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    BirthDate = birthDate;
        //    ContactNo = contactNo;
        //    Email = email;
        //    Address = address;
        //    Username = username;
        //    RoleId = roleId;

        //}
    }
}
