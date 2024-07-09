using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.QueryHandlers
{
    public class GetAllDeliveryAddressQuery : IRequest<ApiResponse<IEnumerable<DeliveryAddressDTO>>>
    {
    }
    public class GetAllDeliveryAddressHandler : IRequestHandler<GetAllDeliveryAddressQuery, ApiResponse<IEnumerable<DeliveryAddressDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllDeliveryAddressHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IEnumerable<DeliveryAddressDTO>>> Handle(GetAllDeliveryAddressQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<DeliveryAddressDTO>>();
            try
            {
                // Get all delivery Address
                var deliveryAddressList = await _unitOfWorkDb.deliveryAddressQueryRepository.GetAllAsync();
                // Map delivery Address to DTOs
                var deliveryAddressDto = deliveryAddressList.Select(item => _mapper.Map<DeliveryAddressDTO>(item));

                response.Data = deliveryAddressDto;
                response.Status = HttpStatusCode.OK;
               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Status = HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
