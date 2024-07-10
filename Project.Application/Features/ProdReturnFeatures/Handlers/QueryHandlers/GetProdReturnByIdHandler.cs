using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.QueryHandlers
{
    public class GetProdReturnByIdQuery : IRequest<ApiResponse<ProdReturnDTO>>
    {
        public GetProdReturnByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetProdReturnByIdHandler : IRequestHandler<GetProdReturnByIdQuery, ApiResponse<ProdReturnDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetProdReturnByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProdReturnDTO>> Handle(GetProdReturnByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ProdReturnDTO>();
            try
            {
                var prodReturn = await _unitOfWorkDb.prodReturnQueryRepository.GetByIdAsync(request.Id);
               

                if (prodReturn == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"product Return with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newProdReturn = _mapper.Map<ProdReturnDTO>(prodReturn);
                response.Data = newProdReturn;
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
