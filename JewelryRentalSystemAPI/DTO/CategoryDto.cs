namespace JewelryRentalSystemAPI.DTO
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }

        public CategoryDto() { }

        public CategoryDto(string categoryName) 
        {
            CategoryName = categoryName;
        }

    }
}
