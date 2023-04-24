using JewelryRentalSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than or equal to 0")]
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public IFormFile ProductImage { get; set; }
        public Product? Product { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Category>? Categories { get; set; }
        public CustomerClassification? CustomerClassification { get; set; }
        public int CustomerClassId { get; set; }
    }
}
