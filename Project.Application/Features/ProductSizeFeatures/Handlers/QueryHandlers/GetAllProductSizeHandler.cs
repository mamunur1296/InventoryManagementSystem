using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.ProductSizeFeatures.Handlers.QueryHandlers
{
    public class GetAllProductSizeQuery : IRequest<ApiResponse<IEnumerable<ProductSizeDTO>>>
    {
    }
    public class GetAllProductSizeHandler : IRequestHandler<GetAllProductSizeQuery, ApiResponse<IEnumerable<ProductSizeDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProductSizeHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IEnumerable<ProductSizeDTO>>> Handle(GetAllProductSizeQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<ProductSizeDTO>>();
            try
            {
                var productSizesList = await _unitOfWorkDb.productSizeQueryRepository.GetAllAsync();
                var restult = productSizesList.Select(x => _mapper.Map<ProductSizeDTO>(x));
                response.Data = restult;
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
