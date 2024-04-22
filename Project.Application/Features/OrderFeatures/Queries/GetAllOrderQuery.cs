using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.OrderFeatures.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<OrderDTO>>
    {
    }
}
