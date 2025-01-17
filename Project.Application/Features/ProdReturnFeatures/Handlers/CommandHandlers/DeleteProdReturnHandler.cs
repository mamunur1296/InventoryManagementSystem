﻿using MediatR;
using Project.Application.Features.ProdReturnFeatures.Commands;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.CommandHandlers
{
    public class DeleteProdReturnHandler : IRequestHandler<DeleteProdReturnCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteProdReturnHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }


        public async Task<string> Handle(DeleteProdReturnCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var prodReturn = await _unitOfWorkDb.prodReturnQueryRepository.GetByIdAsync(request.id);
                if (prodReturn == null)
                {
                    return "Data not found";
                }
                await _unitOfWorkDb.prodReturnCommandRepository.DeleteAsync(prodReturn);
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
