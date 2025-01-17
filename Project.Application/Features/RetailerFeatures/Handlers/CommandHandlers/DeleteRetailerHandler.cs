﻿using MediatR;
using Project.Application.Features.RetailerFeatures.Commands;
using Project.Domail.Abstractions;

namespace Project.Application.Features.RetailerFeatures.Handlers.CommandHandlers
{
    public class DeleteRetailerHandler : IRequestHandler<DeleteRetailerCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteRetailerHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }
        public async Task<string> Handle(DeleteRetailerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retailer = await _unitOfWorkDb.retailerQueryRepository.GetByIdAsync(request.Id);
                if (retailer == null)
                {
                    return "Data not found";
                }
                await _unitOfWorkDb.retailerCommandRepository.DeleteAsync(retailer);
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
