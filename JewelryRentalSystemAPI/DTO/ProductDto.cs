using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JewelryRentalSystemAPI.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string? ProductImage { get; set; }
        

    }
}
