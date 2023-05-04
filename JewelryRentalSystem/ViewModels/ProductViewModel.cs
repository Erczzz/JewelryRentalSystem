using JewelryRentalSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than or equal to 0")]
        public double ProductPrice { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Stock")]
        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than or equal to 0")]
        public int ProductStock { get; set; }
        public IFormFile? ProductImage { get; set; }
        public Product? Product { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Category>? Categories { get; set; }
        public CustomerClassification? CustomerClassification { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int CustomerClassId { get; set; }
    }
}
