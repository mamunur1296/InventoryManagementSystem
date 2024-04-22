using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.CompanyFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile() {
            CreateMap<Company, CompanyModels>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}
