using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.StockFeatures.Queries
{
    public class GetStockByIdQuery : IRequest<StockDTO>
    {
        public GetStockByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

    }
}
