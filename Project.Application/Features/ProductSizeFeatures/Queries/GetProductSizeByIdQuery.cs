using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.ProductSizeFeatures.Queries
{
    public class GetProductSizeByIdQuery : IRequest<ProductSizeDTO>
    {
        public GetProductSizeByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
