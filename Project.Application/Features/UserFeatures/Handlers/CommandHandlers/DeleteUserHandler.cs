﻿using MediatR;
using Project.Application.Features.UserFeatures.Commands;
using Project.Domail.Abstractions;


namespace Project.Application.Features.UserFeatures.Handlers.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteUserHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWorkDb.userQueryRepository.GetByIdAsync(request.Id);
                if (user == null)
                {
                    return "Data not found";
                }
                await _unitOfWorkDb.userCommandRepository.DeleteAsync(user);
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
