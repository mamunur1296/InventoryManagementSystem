using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.RetailerFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.RetailerFeatures.Handlers.QueryHandlers
{
    public class GetRetailerByIdHandler : IRequestHandler<GetRetailerByIdQuery, RetailerDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetRetailerByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<RetailerDTO> Handle(GetRetailerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.retailerQueryRepository.GetByIdAsync(request.Id);
            var newData = _mapper.Map<RetailerDTO>(data);
            return newData;
        }
    }
}
