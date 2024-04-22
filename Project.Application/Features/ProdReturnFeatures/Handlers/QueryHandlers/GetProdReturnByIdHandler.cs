using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.ProdReturnFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.QueryHandlers
{
    public class GetProdReturnByIdHandler : IRequestHandler<GetProdReturnByIdQuery, ProdReturnDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetProdReturnByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ProdReturnDTO> Handle(GetProdReturnByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.prodReturnQueryRepository.GetByIdAsync(request.Id);
            var newData = _mapper.Map<ProdReturnDTO>(data);
            return newData;
        }
    }
}
