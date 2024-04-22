using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.ProductSizeFeatures.Queries
{
    public class GetAllProductSizeQuery : IRequest<IEnumerable<ProductSizeDTO>>
    {
    }
}
