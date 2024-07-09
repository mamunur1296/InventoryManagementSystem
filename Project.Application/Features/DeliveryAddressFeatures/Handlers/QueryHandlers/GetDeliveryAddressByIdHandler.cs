using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.QueryHandlers
{
    public class GetDeliveryAddressByIdQuery : IRequest<ApiResponse<DeliveryAddressDTO>>
    {
        public GetDeliveryAddressByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetDeliveryAddressByIdHandler : IRequestHandler<GetDeliveryAddressByIdQuery, ApiResponse<DeliveryAddressDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetDeliveryAddressByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<DeliveryAddressDTO>> Handle(GetDeliveryAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<DeliveryAddressDTO>();
            try
            {
                var deliveryAddress = await _unitOfWorkDb.deliveryAddressQueryRepository.GetByIdAsync(request.Id);

                if (deliveryAddress == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"delivery Address with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newdeliveryAddress = _mapper.Map<DeliveryAddressDTO>(deliveryAddress);
                response.Data = newdeliveryAddress;
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
