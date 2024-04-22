using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.ProductSizeFeatures.Queries;
using Project.Application.Features.RetailerFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.RetailerFeatures.Handlers.QueryHandlers
{
    public class GetAllRetailerHandler : IRequestHandler<GetAllRetailerQuery, IEnumerable<RetailerDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllRetailerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RetailerDTO>> Handle(GetAllRetailerQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _unitOfWorkDb.retailerQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<RetailerDTO>(x));
            return data;
        }
    }
}
