using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.OrderFeatures.Queries;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

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
                var orderList = await _unitOfWorkDb.orderQueryRepository.GetAllAsync();
                var userList = await _unitOfWorkDb.userQueryRepository.GetAllAsync();
                var productList = await _unitOfWorkDb.productQueryRepository.GetAllAsync();

                var orderDtoTasks = orderList.Select(async order =>
                {
                    var orderDto = _mapper.Map<OrderDTO>(order);
                    orderDto.User = await _unitOfWorkDb.userQueryRepository.GetByIdAsync(order.UserId);
                    orderDto.Product = await _unitOfWorkDb.productQueryRepository.GetByIdAsync(order.ProductId);
                    return orderDto;
                });

                var result = await Task.WhenAll(orderDtoTasks);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
