using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.RetailerFeatures.Commands
{
    public class DeleteRetailerCommand : IRequest<string>
    {
        public DeleteRetailerCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
