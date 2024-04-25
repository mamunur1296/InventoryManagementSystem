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
            try
            {
                var retailer = await _unitOfWorkDb.retailerQueryRepository.GetByIdAsync(request.Id);
                var newretailer = _mapper.Map<RetailerDTO>(retailer);
                return newretailer;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
