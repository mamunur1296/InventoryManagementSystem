using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.RetailerFeatures.Queries
{
    public class GetRetailerByIdQuery : IRequest<RetailerDTO>
    {
        public GetRetailerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
