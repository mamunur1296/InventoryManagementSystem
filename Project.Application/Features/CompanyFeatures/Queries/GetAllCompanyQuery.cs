using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.CompanyFeatures.Queries
{
    public class GetAllCompanyQuery : IRequest<IEnumerable<CompanyDTO>>
    {
    }
}
