using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Mappers
{
    public static class LocationMapper
    {
        public static LocationDto ToDto(this Location location)
        {
            return new LocationDto
            {
                LocationName = location.LocationName
            };
        }

        public static Location ToEntity(this LocationDto locationDto)
        {
            return new Location
            {
                LocationName = locationDto.LocationName
            };
        }
    }
}
