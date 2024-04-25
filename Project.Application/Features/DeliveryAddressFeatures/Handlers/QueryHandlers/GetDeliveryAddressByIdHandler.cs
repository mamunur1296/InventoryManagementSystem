﻿using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.DeliveryAddressFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.QueryHandlers
{
    public class GetDeliveryAddressByIdHandler : IRequestHandler<GetDeliveryAddressByIdQuery, DeliveryAddressDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetDeliveryAddressByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<DeliveryAddressDTO> Handle(GetDeliveryAddressByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var deliveryAddress = await _unitOfWorkDb.deliveryAddressQueryRepository.GetByIdAsync(request.Id);
                var newdeliveryAddress = _mapper.Map<DeliveryAddressDTO>(deliveryAddress);
                return newdeliveryAddress;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
