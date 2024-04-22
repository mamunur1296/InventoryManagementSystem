using MediatR;
using Project.Application.Models;


namespace Project.Application.Features.ValveFeatures.Commands
{
    public class CreateValveCommand : IRequest<ValveModels>
    {
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public bool IsActive { get; set; }
    }
}
