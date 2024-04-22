using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.ProductSizeFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProductSizeFeatures.Handlers.QueryHandlers
{
    public class GetAllProductSizeHandler : IRequestHandler<GetAllProductSizeQuery, IEnumerable<ProductSizeDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProductSizeHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductSizeDTO>> Handle(GetAllProductSizeQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _unitOfWorkDb.productSizeQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<ProductSizeDTO>(x));
            return data;
        }
    }
}
