using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Api.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; }

        public Category() { }

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }
}
