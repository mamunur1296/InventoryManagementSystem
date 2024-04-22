using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.CompanyFeatures.Queries
{
    public class GetAllValveQuery : IRequest<IEnumerable<ValveDTO>>
    {
    }
}
