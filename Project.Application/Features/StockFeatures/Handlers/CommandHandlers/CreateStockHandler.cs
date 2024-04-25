using AutoMapper;
using MediatR;
using Project.Application.Features.StockFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;


namespace Project.Application.Features.StockFeatures.Handlers.CommandHandlers
{
    public class CreateStockHandler : IRequestHandler<CreateStockCommand, StockModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateStockHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
 
        public async Task<StockModels> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var stock = _mapper.Map<Stock>(request);
                await _unitOfWorkDb.stockCommandRepository.AddAsync(stock);
                await _unitOfWorkDb.SaveAsync();
                var stockResponse = _mapper.Map<StockModels>(stock);
                return stockResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
