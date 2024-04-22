using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.TraderFeatures.Queries;
using Project.Domail.Abstractions;


namespace Project.Application.Features.TraderFeatures.Handlers.QueryHandlers
{
    public class GetAllTraderHandler : IRequestHandler<GetAllTraderQuery, IEnumerable<TraderDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllTraderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TraderDTO>> Handle(GetAllTraderQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _unitOfWorkDb.traderQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<TraderDTO>(x));
            return data;
        }
    }
}
