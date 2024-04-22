using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.ProductFeatures.Queries;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ProductFeatures.Handlers.QueryHandlers
{
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
            var dataList = await _unitOfWorkDb.productQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<ProductDTO>(x));
            return data;
        }
    }
}
