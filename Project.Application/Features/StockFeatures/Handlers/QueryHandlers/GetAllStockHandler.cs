using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;


namespace Project.Application.Features.StockFeatures.Handlers.QueryHandlers
{
    public class GetAllStockQuery : IRequest<ApiResponse<IEnumerable<StockDTO>>>
    {
    }
    public class GetAllStockHandler : IRequestHandler<GetAllStockQuery, ApiResponse<IEnumerable<StockDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllStockHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<StockDTO>>> Handle(GetAllStockQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<StockDTO>>();
            try
            {
                var stockList = await _unitOfWorkDb.stockQueryRepository.GetAllAsync();
                var result = stockList.Select(x => _mapper.Map<StockDTO>(x));
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
