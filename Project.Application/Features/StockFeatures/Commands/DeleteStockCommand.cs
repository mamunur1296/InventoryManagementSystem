using MediatR;

namespace Project.Application.Features.StockFeatures.Commands
{
    public class DeleteStockCommand : IRequest<string>
    {
        public DeleteStockCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
