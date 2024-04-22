using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.ProdReturnFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.QueryHandlers
{
    public class GetAllProdReturnHandler : IRequestHandler<GetAllProdReturnQuery, IEnumerable<ProdReturnDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProdReturnHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProdReturnDTO>> Handle(GetAllProdReturnQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _unitOfWorkDb.prodReturnQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<ProdReturnDTO>(x));
            return data;
        }
    }
}
