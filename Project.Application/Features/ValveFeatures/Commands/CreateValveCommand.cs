using MediatR;
using Project.Application.Models;


namespace Project.Application.Features.ValveFeatures.Commands
{
    public class CreateValveCommand : IRequest<ValveModels>
    {
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
