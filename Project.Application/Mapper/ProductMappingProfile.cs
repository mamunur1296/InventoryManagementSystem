using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Models;
using Project.Domail.Entities;


namespace Project.Application.Mapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductModels>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
