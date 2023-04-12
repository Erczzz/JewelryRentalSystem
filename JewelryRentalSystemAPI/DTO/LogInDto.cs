using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystemAPI.DTO
{
    public class LogInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
