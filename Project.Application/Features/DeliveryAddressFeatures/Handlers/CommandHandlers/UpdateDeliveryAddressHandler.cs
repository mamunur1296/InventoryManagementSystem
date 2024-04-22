using AutoMapper;
using MediatR;
using Project.Application.Features.DeliveryAddressFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.CommandHandlers
{
    public class UpdateDeliveryAddressHandler : IRequestHandler<UpdateDeliveryAddressCommand, DeliveryAddressModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateDeliveryAddressHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<DeliveryAddressModels> Handle(UpdateDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.deliveryAddressQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.Address = request.Address;
                data.Phone = request.Phone;
                data.IsDefault = request.IsDefault;
                // add more fildes
            }
            await _unitOfWorkDb.deliveryAddressCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<DeliveryAddressModels>(data);
            return customerRes;
        }
    }
}
