using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.Net;


namespace Project.Application.Features.ValveFeatures.Handlers.QueryHandlers
{
    public class GetValveByIdQuery : IRequest<ApiResponse<ValveDTO>>
    {
        public GetValveByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetValveByIdHandler : IRequestHandler<GetValveByIdQuery, ApiResponse<ValveDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetValveByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ValveDTO>> Handle(GetValveByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ValveDTO>();
            try
            {
                var valve = await _unitOfWorkDb.valverQueryRepository.GetByIdAsync(request.Id);
                if (valve == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"valve with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }

                var newvalve = _mapper.Map<ValveDTO>(valve);
                response.Data = newvalve;
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

