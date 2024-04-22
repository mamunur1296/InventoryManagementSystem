using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.RetailerFeatures.Queries
{
    public class GetAllRetailerQuery : IRequest<IEnumerable<RetailerDTO>>
    {
    }
}
