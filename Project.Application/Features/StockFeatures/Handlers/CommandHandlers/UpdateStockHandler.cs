using AutoMapper;
using MediatR;
using Project.Application.Features.StockFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;


namespace Project.Application.Features.StockFeatures.Handlers.CommandHandlers
{
    public class UpdateStockHandler : IRequestHandler<UpdateStockCommand, StockModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateStockHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }



        public async Task<StockModels> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var stock = await _unitOfWorkDb.stockQueryRepository.GetByIdAsync(request.Id);
                if (stock == null) return default;
                else
                {
                    stock.UpdatedBy = request.UpdatedBy;
                }
                await _unitOfWorkDb.stockCommandRepository.UpdateAsync(stock);
                await _unitOfWorkDb.SaveAsync();
                var stockRes = _mapper.Map<StockModels>(stock);
                return stockRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
