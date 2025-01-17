﻿using MediatR;
using Project.Application.Features.DeliveryAddressFeatures.Commands;
using Project.Domail.Abstractions;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.CommandHandlers
{
    public class DeleteDeliveryAddressHandler : IRequestHandler<DeleteDeliveryAddressCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteDeliveryAddressHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }
 
        public async Task<string> Handle(DeleteDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deliveryAddress = await _unitOfWorkDb.deliveryAddressQueryRepository.GetByIdAsync(request.Id);
                if (deliveryAddress == null)
                {
                    return "Data not found";
                }
                await _unitOfWorkDb.deliveryAddressCommandRepository.DeleteAsync(deliveryAddress);
                await _unitOfWorkDb.SaveAsync();
                return "Completed";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
