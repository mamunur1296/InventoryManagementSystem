using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Application.Features.ProdReturnFeatures.Handlers.QueryHandlers;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.Net;

namespace Project.Application.Features.ProductDiscuntFeatures.Handlers.QueryHandlers
{
    public class GetProductDiscuntByIdQuery : IRequest<ApiResponse<ProductDiscuntDTO>>
    {
        public GetProductDiscuntByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetProductDiscuntByIdHandler : IRequestHandler<GetProductDiscuntByIdQuery, ApiResponse<ProductDiscuntDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetProductDiscuntByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductDiscuntDTO>> Handle(GetProductDiscuntByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ProductDiscuntDTO>();
            try
            {
                var productDiscount = await _unitOfWorkDb.productDiscuntQueryRepository.GetByIdAsync(request.Id);

                if (productDiscount == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"product Discount with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }
                var newproductDiscount = _mapper.Map<ProductDiscuntDTO>(productDiscount);
                response.Data = newproductDiscount;
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


