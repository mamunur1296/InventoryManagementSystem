using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.DeliveryAddressFeatures.Queries;
using Project.Domail.Abstractions;

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
            var dataList = await _unitOfWorkDb.deliveryAddressQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<DeliveryAddressDTO>(x));
            return data;
        }
    }
}
