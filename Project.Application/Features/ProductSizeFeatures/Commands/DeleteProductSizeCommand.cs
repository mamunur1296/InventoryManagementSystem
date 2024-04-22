using MediatR;

namespace Project.Application.Features.ProductSizeFeatures.Commands
{
    public class DeleteProductSizeCommand : IRequest<string>
    {
        public DeleteProductSizeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
