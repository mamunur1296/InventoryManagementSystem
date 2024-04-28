using AutoMapper;
using MediatR;
using Project.Application.Features.OrderFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;

namespace Project.Application.Features.OrderFeatures.Handlers.CommandHandlers
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, OrderModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateOrderHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<OrderModels> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _unitOfWorkDb.orderQueryRepository.GetByIdAsync(request.Id);
                if (order == null) return default;
                else
                {
                    order.IsCancel = true;
                    order.CreatedBy = request.CreatedBy;
                    order.CreationDate = request.CreationDate;
                    order.IsCancel = request.IsCancel;
                    order.Name = request.Name
                    // extand 
                }
                await _unitOfWorkDb.orderCommandRepository.UpdateAsync(order);
                await _unitOfWorkDb.SaveAsync();
                var orderRes = _mapper.Map<OrderModels>(order);
                return orderRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
