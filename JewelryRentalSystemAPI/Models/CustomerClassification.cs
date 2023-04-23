using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystemAPI.Models
{
    public class CustomerClassification
    {
        [Key]
        public int CustomerClassId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Classification Name")]
        public string CustomerClassName { get; set; }
        public int ItemLimit { get; set; }
        public int RentLimit { get; set; }
        public List<Product>? Products { get; set; }
        public List<ApplicationUser>? Users { get; set; }
        public CustomerClassification()
        {
            
        }

        public CustomerClassification(int customerClassId, string customerClassName, int itemLimit, int rentLimit)
        {
            CustomerClassId = customerClassId;
            CustomerClassName = customerClassName;
            ItemLimit = itemLimit;
            RentLimit = rentLimit;
        }
    }
}
