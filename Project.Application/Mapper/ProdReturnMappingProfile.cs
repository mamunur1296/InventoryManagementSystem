using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class ProdReturnMappingProfile : Profile
    {
        public ProdReturnMappingProfile() {
            CreateMap<ProdReturn, ProdReturnModels>().ReverseMap();
            CreateMap<ProdReturn, ProdReturnDTO>().ReverseMap();
        }
    }
}
