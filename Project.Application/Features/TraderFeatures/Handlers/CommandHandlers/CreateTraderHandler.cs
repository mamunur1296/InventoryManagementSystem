using AutoMapper;
using MediatR;
using Project.Application.Features.TraderFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.TraderFeatures.Handlers.CommandHandlers
{
    public class CreateTraderHandler : IRequestHandler<CreateTraderCommand, TraderModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateTraderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<TraderModels> Handle(CreateTraderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Trader = _mapper.Map<Trader>(request);
                await _unitOfWorkDb.traderCommandRepository.AddAsync(Trader);
                await _unitOfWorkDb.SaveAsync();
                var newTrader = _mapper.Map<TraderModels>(Trader);
                return newTrader;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
