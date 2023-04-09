using AutoMapper;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;
using System.Runtime;

namespace JewelryRentalSystemAPI.Helper
{
    public class MappingProduct : Profile
    {
        public MappingProduct() 
        { 
            CreateMap<Product, ProductDto>();
        }

    }
}
