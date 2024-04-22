using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.ProdReturnFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class ProdReturnMappingProfile : Profile
    {
        public ProdReturnMappingProfile() {
            CreateMap<ProdReturn, ProdReturnModels>().ReverseMap();
            CreateMap<ProdReturn, CreateProdReturnCommand>().ReverseMap();
            CreateMap<ProdReturn, UpdateProdReturnCommand>().ReverseMap();
            CreateMap<ProdReturn, ProdReturnDTO>().ReverseMap();
        }
    }
}
