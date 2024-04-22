using AutoMapper;
using MediatR;
using Project.Application.Features.CompanyFeatures.Commands;
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
            var data = await _unitOfWorkDb.stockQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.UpdatedBy = request.UpdatedBy;
            }
            await _unitOfWorkDb.stockCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<StockModels>(data);
            return customerRes;
        }
    }
}
