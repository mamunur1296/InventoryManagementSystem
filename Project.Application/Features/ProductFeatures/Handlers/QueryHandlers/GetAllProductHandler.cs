using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ProductFeatures.Handlers.QueryHandlers
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetch data from repositories
                var productList = await _unitOfWorkDb.productQueryRepository.GetAllAsync();
                var stockList = await _unitOfWorkDb.stockQueryRepository.GetAllAsync();

                // Combine the product and stock data
                var combinedResult = productList.Select(product =>
                {
                    var stock = stockList.FirstOrDefault(s => s.ProductId == product.Id);

                    return new ProductDTO
                    {
                        Id = product.Id,
                        CompanyId = product.CompanyId,
                        Name = product.Name,
                        ProdSizeId = product.ProdSizeId,
                        ProdValveId = product.ProdValveId,
                        ProdImage = product?.ProdImage,
                        ProdPrice = product.ProdPrice,
                        CreatedBy = product?.CreatedBy,
                        UpdatedBy = product?.UpdatedBy,
                        IsActive = product.IsActive,
                        IsStock = stock?.Quantity ?? 0
                    };
                });

                return combinedResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
