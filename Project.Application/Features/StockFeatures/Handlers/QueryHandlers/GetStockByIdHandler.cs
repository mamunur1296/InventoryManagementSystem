using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.StockFeatures.Queries;
using Project.Domail.Abstractions;


namespace Project.Application.Features.StockFeatures.Handlers.QueryHandlers
{
    public class GetStockByIdHandler : IRequestHandler<GetStockByIdQuery, StockDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetStockByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<StockDTO> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.stockQueryRepository.GetByIdAsync(request.Id);
            var newData = _mapper.Map<StockDTO>(data);
            return newData;
        }
    }
}
