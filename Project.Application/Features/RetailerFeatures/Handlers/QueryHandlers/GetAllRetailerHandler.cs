using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.RetailerFeatures.Handlers.QueryHandlers
{
    public class GetAllRetailerQuery : IRequest<ApiResponse<IEnumerable<RetailerDTO>>>
    {
    }
    public class GetAllRetailerHandler : IRequestHandler<GetAllRetailerQuery, ApiResponse<IEnumerable<RetailerDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllRetailerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<ApiResponse<IEnumerable<RetailerDTO>>> Handle(GetAllRetailerQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<RetailerDTO>>();
            try
            {
                var retailerList = await _unitOfWorkDb.retailerQueryRepository.GetAllAsync();
                var result = retailerList.Select(x => _mapper.Map<RetailerDTO>(x));
                response.Data = result;
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
