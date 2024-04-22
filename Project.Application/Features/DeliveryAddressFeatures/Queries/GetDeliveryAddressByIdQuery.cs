using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.DeliveryAddressFeatures.Queries
{
    public class GetDeliveryAddressByIdQuery : IRequest<DeliveryAddressDTO>
    {
        public GetDeliveryAddressByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    
}
