using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.ProductFeatures.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
