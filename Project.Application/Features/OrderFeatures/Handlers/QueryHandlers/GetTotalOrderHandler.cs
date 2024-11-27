using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Domail.Abstractions;

namespace Project.Application.Features.OrderFeatures.Handlers.QueryHandlers
{
    public class GetTotalOrderQuery : IRequest<IEnumerable<OrderDTO>>
    {
        
    }
    public class GetTotalOrderHandler : IRequestHandler<GetTotalOrderQuery, IEnumerable<OrderDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetTotalOrderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetTotalOrderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _unitOfWorkDb.orderQueryRepository.GetAllAsync();
                

                // Map the filtered orders to OrderDTO
                var ordersDto = orders.Select(item => _mapper.Map<OrderDTO>(item));
                return ordersDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
