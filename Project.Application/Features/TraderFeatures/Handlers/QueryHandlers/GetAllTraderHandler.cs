using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;


namespace Project.Application.Features.TraderFeatures.Handlers.QueryHandlers
{
    public class GetAllTraderQuery : IRequest<ApiResponse<IEnumerable<TraderDTO>>>
    {
    }
    public class GetAllTraderHandler : IRequestHandler<GetAllTraderQuery, ApiResponse<IEnumerable<TraderDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllTraderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TraderDTO>>> Handle(GetAllTraderQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<TraderDTO>>();
            try
            {
                var TraderList = await _unitOfWorkDb.traderQueryRepository.GetAllAsync();
                var result = TraderList.Select(x => _mapper.Map<TraderDTO>(x));
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
