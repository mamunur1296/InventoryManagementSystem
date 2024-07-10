using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.ProductDiscuntFeatures.Handlers.QueryHandlers
{
    public class GetAllProductDiscuntQuery : IRequest<ApiResponse<IEnumerable<ProductDiscuntDTO>>>
    {
    }
    public class GetAllProductDiscuntHandler : IRequestHandler<GetAllProductDiscuntQuery, ApiResponse<IEnumerable<ProductDiscuntDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProductDiscuntHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IEnumerable<ProductDiscuntDTO>>> Handle(GetAllProductDiscuntQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<ProductDiscuntDTO>>();
            try
            {


                // Get all ProductDiscunt
                var productDiscuntList = await _unitOfWorkDb.productDiscuntQueryRepository.GetAllAsync();
                // Map ProductDiscunt to DTOs
                var result = productDiscuntList.Select(x => _mapper.Map<ProductDiscuntDTO>(x));

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
