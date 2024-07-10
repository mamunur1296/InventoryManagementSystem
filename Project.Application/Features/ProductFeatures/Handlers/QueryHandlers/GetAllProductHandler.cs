using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;


namespace Project.Application.Features.ProductFeatures.Handlers.QueryHandlers
{
    public class GetAllProductQuery : IRequest<ApiResponse<IEnumerable<ProductDTO>>>
    {
    }
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, ApiResponse<IEnumerable<ProductDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<ApiResponse<IEnumerable<ProductDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<ProductDTO>>();
            try
            {
                
                var productList = await _unitOfWorkDb.productQueryRepository.GetAllAsync();
                var result = productList.Select(x => _mapper.Map<ProductDTO>(x));

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


