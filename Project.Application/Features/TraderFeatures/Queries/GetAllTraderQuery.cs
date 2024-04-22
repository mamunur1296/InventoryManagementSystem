using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.TraderFeatures.Queries
{
    public class GetAllTraderQuery : IRequest<IEnumerable<TraderDTO>>
    {
    }
}
