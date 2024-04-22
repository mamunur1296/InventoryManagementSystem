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
            var data = await _unitOfWorkDb.traderQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.Name = request.Name;
            }
            await _unitOfWorkDb.traderCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<TraderModels>(data);
            return customerRes;
        }
    }
}
