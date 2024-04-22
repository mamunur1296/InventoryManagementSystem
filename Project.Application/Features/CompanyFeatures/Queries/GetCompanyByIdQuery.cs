using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.CompanyFeatures.Queries
{
    public class GetCompanyByIdQuery : IRequest<CompanyDTO>
    {
        public GetCompanyByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    
}
