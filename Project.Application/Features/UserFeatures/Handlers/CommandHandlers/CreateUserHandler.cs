using AutoMapper;
using MediatR;
using Project.Application.Features.UserFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;


namespace Project.Application.Features.UserFeatures.Handlers.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<UserModels> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                await _unitOfWorkDb.userCommandRepository.AddAsync(user);
                await _unitOfWorkDb.SaveAsync();
                var newUser = _mapper.Map<UserModels>(user);
                return newUser;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
