using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;


namespace Project.Application.Features.TraderFeatures.Handlers.QueryHandlers
{
    public class GetTraderByIdQuery : IRequest<ApiResponse<TraderDTO>>
    {
        public GetTraderByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

    }
    public class GetTraderByIdHandler : IRequestHandler<GetTraderByIdQuery, ApiResponse<TraderDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetTraderByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TraderDTO>> Handle(GetTraderByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<TraderDTO>();
            try
            {
                var trader = await _unitOfWorkDb.traderQueryRepository.GetByIdAsync(request.Id);
                if (trader == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"trader with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newTrader = _mapper.Map<TraderDTO>(trader);
                response.Data = newTrader;
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
