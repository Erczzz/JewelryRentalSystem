using AutoMapper;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;
using System.Runtime;

namespace JewelryRentalSystemAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        { 
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
        }

    }
}
