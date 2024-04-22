using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.OrderFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.OrderFeatures.Handlers.QueryHandlers
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<OrderDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllOrderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dataList = await _unitOfWorkDb.orderQueryRepository.GetAllAsync();
                var data = dataList.Select(x => _mapper.Map<OrderDTO>(x));
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
