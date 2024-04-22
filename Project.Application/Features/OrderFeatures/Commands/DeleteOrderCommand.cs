using MediatR;

namespace Project.Application.Features.OrderFeatures.Commands
{
    public class DeleteOrderCommand : IRequest<string>
    {
        public DeleteOrderCommand(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; private set; }
    }
}
