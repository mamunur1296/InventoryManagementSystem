using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;


namespace Project.Application.Features.ValveFeatures.Handlers.QueryHandlers
{
    public class GetAllValveQuery : IRequest<ApiResponse<IEnumerable<ValveDTO>>>
    {
    }
    public class GetAllValveHandler : IRequestHandler<GetAllValveQuery, ApiResponse<IEnumerable<ValveDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllValveHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
 
        public async Task<ApiResponse<IEnumerable<ValveDTO>>> Handle(GetAllValveQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<ValveDTO>>();
            try
            {
                var valveList = await _unitOfWorkDb.valverQueryRepository.GetAllAsync();
                var result = valveList.Select(x => _mapper.Map<ValveDTO>(x));
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
