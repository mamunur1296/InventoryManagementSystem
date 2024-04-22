using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.CompanyFeatures.Queries
{
    public class GetValveByIdQuery : IRequest<ValveDTO>
    {
        public GetValveByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    
}
