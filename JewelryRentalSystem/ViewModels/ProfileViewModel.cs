﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class ProfileViewModel
    {
        [Key]
        public string CustomerId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Birthday")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [MinLength(11)]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        public string ContactNo { get; set; }

        [Required]
        public string Address { get; set; }
        [DisplayName("Eligibility")]
        public string CustomerClassName { get; set; }
        [DisplayName("Item Limit")]
        public int ItemLimit { get; set; }
        [DisplayName("Rent Limit")]
        public int RentLimit { get; set; }


    }
}
