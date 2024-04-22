using MediatR;

namespace Project.Application.Features.ProductFeatures.Commands
{
    public class DeleteProductCommand : IRequest<string>
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
