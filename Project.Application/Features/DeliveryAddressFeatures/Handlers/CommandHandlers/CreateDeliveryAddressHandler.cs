using AutoMapper;
using MediatR;
using Project.Application.Features.DeliveryAddressFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.CommandHandlers
{
    public class CreateDeliveryAddressHandler : IRequestHandler<CreateDeliveryAddressCommand, DeliveryAddressModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateDeliveryAddressHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<DeliveryAddressModels> Handle(CreateDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deliveryAddress = _mapper.Map<DeliveryAddress>(request);
                await _unitOfWorkDb.deliveryAddressCommandRepository.AddAsync(deliveryAddress);
                await _unitOfWorkDb.SaveAsync();
                var newdeliveryAddress = _mapper.Map<DeliveryAddressModels>(deliveryAddress);
                return newdeliveryAddress;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
