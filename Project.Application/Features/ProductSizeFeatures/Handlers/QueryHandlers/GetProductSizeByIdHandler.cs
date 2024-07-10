using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.ProductSizeFeatures.Handlers.QueryHandlers
{
    public class GetProductSizeByIdQuery : IRequest<ApiResponse<ProductSizeDTO>>
    {
        public GetProductSizeByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetProductSizeByIdHandler : IRequestHandler<GetProductSizeByIdQuery, ApiResponse<ProductSizeDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetProductSizeByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
       
        public async Task<ApiResponse<ProductSizeDTO>> Handle(GetProductSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ProductSizeDTO>();
            try
            {
                var productSize = await _unitOfWorkDb.productSizeQueryRepository.GetByIdAsync(request.Id);
                if (productSize == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"product Size with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newProductSize = _mapper.Map<ProductSizeDTO>(productSize);
                response.Data = newProductSize;
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
