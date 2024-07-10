using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;


namespace Project.Application.Features.OrderFeatures.Handlers.QueryHandlers
{
    public class GetAllOrderQuery : IRequest<ApiResponse<IEnumerable<OrderDTO>>>
    {
    }
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, ApiResponse<IEnumerable<OrderDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllOrderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<OrderDTO>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<OrderDTO>>();
            try
            {
                
                
                // Get all orders
                var orders = await _unitOfWorkDb.orderQueryRepository.GetAllAsync();
                // Map orders to DTOs
                var ordersDto = orders.Select(item => _mapper.Map<OrderDTO>(item));

                response.Data = ordersDto;
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
