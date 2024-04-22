using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.ValveFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;


namespace Project.Application.Mapper
{
    public class ValveMappingProfile : Profile
    {
        public ValveMappingProfile()
        {
            CreateMap<Valve, ValveModels>().ReverseMap();
            CreateMap<Valve, CreateValveCommand>().ReverseMap();
            CreateMap<Valve, UpdateValveCommand>().ReverseMap();
            CreateMap<Valve, ValveDTO>().ReverseMap();
        }
    }
}
