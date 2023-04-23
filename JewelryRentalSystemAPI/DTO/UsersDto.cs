﻿using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryRentalSystemAPI.DTO
{
    public class UsersDto
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? Birthdate { get; set; }
            public string ContactNo { get; set; }
            public string Address { get; set; }

            public ICollection<Cart> Carts { get; set; } = new List<Cart>();
            public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
            public bool isActive { get; set; } = true;

            public int? CustClassId { get; set; } = 1;
            [ForeignKey("CustClassId")]
            public CustomerClassification? CustomerClassification { get; set; }
        
    }
}
