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
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<ApplicationUser, SignUpDto>().ReverseMap()
                .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));

            CreateMap<ApplicationUser, LogInDto>().ReverseMap()
                .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));
        }

    }
}
