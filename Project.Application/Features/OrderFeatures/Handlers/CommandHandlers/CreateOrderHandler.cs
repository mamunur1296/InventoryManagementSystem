using AutoMapper;
using MediatR;
using Project.Application.Features.OrderFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.OrderFeatures.Handlers.CommandHandlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
 

        public async Task<OrderModels> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _mapper.Map<Order>(request);
                await _unitOfWorkDb.orderCommandRepository.AddAsync(order);
                await _unitOfWorkDb.SaveAsync();
                var newOrder = _mapper.Map<OrderModels>(order);
                return newOrder;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
