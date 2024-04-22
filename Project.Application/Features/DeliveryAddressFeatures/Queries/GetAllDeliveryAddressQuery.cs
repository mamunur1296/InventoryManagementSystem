using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.DeliveryAddressFeatures.Queries
{
    public class GetAllDeliveryAddressQuery : IRequest<IEnumerable<DeliveryAddressDTO>>
    {
    }
}
