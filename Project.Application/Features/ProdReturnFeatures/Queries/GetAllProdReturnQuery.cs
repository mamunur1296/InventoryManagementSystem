using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.ProdReturnFeatures.Queries
{
    public class GetAllProdReturnQuery :  IRequest<IEnumerable<ProdReturnDTO>>
    {
    }
}
