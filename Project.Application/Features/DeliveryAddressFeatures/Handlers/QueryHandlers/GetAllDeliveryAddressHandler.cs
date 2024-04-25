using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.DeliveryAddressFeatures.Queries;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.QueryHandlers
{
    public class GetAllDeliveryAddressHandler : IRequestHandler<GetAllDeliveryAddressQuery, IEnumerable<DeliveryAddressDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllDeliveryAddressHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<IEnumerable<DeliveryAddressDTO>> Handle(GetAllDeliveryAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userList = await _unitOfWorkDb.userQueryRepository.GetAllAsync();
                var deliveryAddressList = await _unitOfWorkDb.deliveryAddressQueryRepository.GetAllAsync();

                var deliveryAddressDto = deliveryAddressList.Select(async deliveryAddress =>
                {
                    var deliveryAddressDto = _mapper.Map<DeliveryAddressDTO>(deliveryAddress);
                    deliveryAddressDto.User = await _unitOfWorkDb.userQueryRepository.GetByIdAsync(deliveryAddressDto.UserId);
                    return deliveryAddressDto;
                });
                var data = await Task.WhenAll(deliveryAddressDto);
                return data;
               
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}
