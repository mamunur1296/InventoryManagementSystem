using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public GetProductByIdQuery(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; private set; }
    }
}
