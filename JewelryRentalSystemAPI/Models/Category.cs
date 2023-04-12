using JewelryRentalSystemAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystemAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
        
    }
}
