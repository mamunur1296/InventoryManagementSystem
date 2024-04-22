using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.OrderFeatures.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDTO>
    {
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
