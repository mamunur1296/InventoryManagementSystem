using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.StockFeatures.Queries
{
    public class GetAllStockQuery :IRequest<IEnumerable<StockDTO>>
    {
    }
}
