using MediatR;

namespace Project.Application.Features.ValveFeatures.Commands
{
    public class DeleteValveCommand : IRequest<string>
    {
        public DeleteValveCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
