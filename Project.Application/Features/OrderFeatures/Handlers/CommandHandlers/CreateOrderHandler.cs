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
                var productSizeEntity = _mapper.Map<Order>(request);
                await _unitOfWorkDb.orderCommandRepository.AddAsync(productSizeEntity);
                await _unitOfWorkDb.SaveAsync();
                var newResponse = _mapper.Map<OrderModels>(productSizeEntity);
                return newResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
