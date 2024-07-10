using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.Net;

namespace Project.Application.Features.RetailerFeatures.Handlers.QueryHandlers
{
    public class GetRetailerByIdQuery : IRequest<ApiResponse<RetailerDTO>>
    {
        public GetRetailerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetRetailerByIdHandler : IRequestHandler<GetRetailerByIdQuery, ApiResponse<RetailerDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetRetailerByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<RetailerDTO>> Handle(GetRetailerByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<RetailerDTO>();
            try
            {
                var retailer = await _unitOfWorkDb.retailerQueryRepository.GetByIdAsync(request.Id);
                if (retailer == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"retailer with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newretailer = _mapper.Map<RetailerDTO>(retailer);
                response.Data = newretailer;
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
