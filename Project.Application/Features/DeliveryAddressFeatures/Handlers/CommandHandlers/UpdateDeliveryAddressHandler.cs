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
            try
            {
                var deliveryAddress = await _unitOfWorkDb.deliveryAddressQueryRepository.GetByIdAsync(request.Id);
                if (deliveryAddress == null) return default;
                else
                {
                    deliveryAddress.UserId = request.UserId;
                    deliveryAddress.Address = request.Address;
                    deliveryAddress.Phone = request.Phone;
                    deliveryAddress.Mobile = request.Mobile;
                    deliveryAddress.CreatedBy = request.CreatedBy;
                    deliveryAddress.UpdatedBy = request.UpdatedBy;
                    deliveryAddress.IsActive = request.IsActive;
                    deliveryAddress.DeactivatedDate = request.DeactivatedDate;
                    deliveryAddress.DeactiveBy = request.DeactiveBy;
                    deliveryAddress.IsDefault = request.IsDefault;
                    // add more fildes
                }
                await _unitOfWorkDb.deliveryAddressCommandRepository.UpdateAsync(deliveryAddress);
                await _unitOfWorkDb.SaveAsync();
                var deliveryAddressRes = _mapper.Map<DeliveryAddressModels>(deliveryAddress);
                return deliveryAddressRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
