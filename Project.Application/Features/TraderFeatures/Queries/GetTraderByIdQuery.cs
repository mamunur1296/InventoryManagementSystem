using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.TraderFeatures.Queries
{
    public class GetTraderByIdQuery : IRequest<TraderDTO>
    {
        public GetTraderByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

    }
}
