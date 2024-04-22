using MediatR;

namespace Project.Application.Features.DeliveryAddressFeatures.Commands
{
    public class DeleteDeliveryAddressCommand : IRequest<string>
    {
        public DeleteDeliveryAddressCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }    
    }
}
