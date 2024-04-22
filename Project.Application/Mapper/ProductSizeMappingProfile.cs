using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.ProductSizeFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class ProductSizeMappingProfile : Profile
    {
        public ProductSizeMappingProfile() {
            CreateMap<ProductSize, ProductSizeModels>().ReverseMap();
            CreateMap<ProductSize, CreateProductSizeCommand>().ReverseMap();
            CreateMap<ProductSize, UpdateProductSizeCommand>().ReverseMap();
            CreateMap<ProductSize, ProductSizeDTO>().ReverseMap();
        }
    }
}
