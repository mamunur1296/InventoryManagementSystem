using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.Net;


namespace Project.Application.Features.ProductFeatures.Handlers.QueryHandlers
{
    public class GetProductByIdQuery : IRequest<ApiResponse<ProductDTO>>
    {
        public GetProductByIdQuery(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; private set; }
    }
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
  
        public async Task<ApiResponse<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ProductDTO>();
            try
            {
                var product = await _unitOfWorkDb.productQueryRepository.GetByIdAsync(request.id);
                if (product == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"product  with id = {request.id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newProduct = _mapper.Map<ProductDTO>(product);
                response.Data = newProduct;
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
