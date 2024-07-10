using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.QueryHandlers
{
    public class GetAllProdReturnQuery : IRequest<ApiResponse<IEnumerable<ProdReturnDTO>>>
    {
    }
    public class GetAllProdReturnHandler : IRequestHandler<GetAllProdReturnQuery, ApiResponse<IEnumerable<ProdReturnDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProdReturnHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IEnumerable<ProdReturnDTO>>> Handle(GetAllProdReturnQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<ProdReturnDTO>>();
            try
            {



                // Get all prodReturn
                var prodReturnList = await _unitOfWorkDb.prodReturnQueryRepository.GetAllAsync();
                // Map prodReturn to DTOs
                var result = prodReturnList.Select(x => _mapper.Map<ProdReturnDTO>(x));

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
