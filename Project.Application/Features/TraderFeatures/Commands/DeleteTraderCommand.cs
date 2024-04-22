using MediatR;


namespace Project.Application.Features.TraderFeatures.Commands
{
    public class DeleteTraderCommand : IRequest<string>
    {
        public DeleteTraderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
