using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.ProdReturnFeatures.Queries
{
    public class GetProdReturnByIdQuery : IRequest<ProdReturnDTO>
    {
        public GetProdReturnByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
