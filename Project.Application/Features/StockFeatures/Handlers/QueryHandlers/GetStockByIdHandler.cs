using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;


namespace Project.Application.Features.StockFeatures.Handlers.QueryHandlers
{
    public class GetStockByIdQuery : IRequest<ApiResponse<StockDTO>>
    {
        public GetStockByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

    }
    public class GetStockByIdHandler : IRequestHandler<GetStockByIdQuery, ApiResponse<StockDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetStockByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<ApiResponse<StockDTO>> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<StockDTO>();
            try
            {
                var stock = await _unitOfWorkDb.stockQueryRepository.GetByIdAsync(request.Id);
                if (stock == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"stock with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newStock = _mapper.Map<StockDTO>(stock);
                response.Data = newStock;
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
