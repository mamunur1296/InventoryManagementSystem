using AutoMapper;
using MediatR;
using Project.Application.Features.TraderFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;


namespace Project.Application.Features.TraderFeatures.Handlers.CommandHandlers
{
    public class UpdateTraderHandler : IRequestHandler<UpdateTraderCommand, TraderModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateTraderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<TraderModels> Handle(UpdateTraderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Trader = await _unitOfWorkDb.traderQueryRepository.GetByIdAsync(request.Id);
                if (Trader == null) return default;
                else
                {
                    Trader.Name = request.Name;
                }
                await _unitOfWorkDb.traderCommandRepository.UpdateAsync(Trader);
                await _unitOfWorkDb.SaveAsync();
                var TraderRes = _mapper.Map<TraderModels>(Trader);
                return TraderRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
