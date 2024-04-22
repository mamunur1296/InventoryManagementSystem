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
                var data = await _unitOfWorkDb.orderQueryRepository.GetByIdAsync(request.Id);
                if (data == null) return default;
                else
                {
                    data.IsCancel = true;
                    data.CreatedBy = request.CreatedBy;
                    // extand 
                }
                await _unitOfWorkDb.orderCommandRepository.UpdateAsync(data);
                await _unitOfWorkDb.SaveAsync();
                var customerRes = _mapper.Map<OrderModels>(data);
                return customerRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
