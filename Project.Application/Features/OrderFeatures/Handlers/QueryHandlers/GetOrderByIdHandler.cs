using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.OrderFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.OrderFeatures.Handlers.QueryHandlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _unitOfWorkDb.orderQueryRepository.GetByIdAsync(request.Id);
                var newData = _mapper.Map<OrderDTO>(data);
                return newData;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
