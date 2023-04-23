namespace JewelryRentalSystemAPI.DTO
{
    public class LocationDto
    {
        public string LocationName { get; set; }
        public LocationDto()
        {

        }

        public LocationDto( string locationName)
        {
            LocationName = locationName;
        }
    }
}
