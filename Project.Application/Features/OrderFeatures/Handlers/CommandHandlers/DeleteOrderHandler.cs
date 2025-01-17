﻿using MediatR;
using Project.Application.Features.OrderFeatures.Commands;
using Project.Domail.Abstractions;

namespace Project.Application.Features.OrderFeatures.Handlers.CommandHandlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteOrderHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }
   

        public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _unitOfWorkDb.orderQueryRepository.GetByIdAsync(request.id);
                if (order == null)
                {
                    return "Data not found";
                }
                await _unitOfWorkDb.orderCommandRepository.DeleteAsync(order);
                await _unitOfWorkDb.SaveAsync();
                return "Completed";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
