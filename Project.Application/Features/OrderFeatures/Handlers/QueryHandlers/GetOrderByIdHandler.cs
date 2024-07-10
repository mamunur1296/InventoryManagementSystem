using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.OrderFeatures.Handlers.QueryHandlers
{
    public class GetOrderByIdQuery : IRequest<ApiResponse<OrderDTO>>
    {
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<ApiResponse<OrderDTO>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<OrderDTO>();
            try
            {
                var order = await _unitOfWorkDb.orderQueryRepository.GetByIdAsync(request.Id);

                if (order == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"order with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var neworder = _mapper.Map<OrderDTO>(order);
                response.Data = neworder;
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
