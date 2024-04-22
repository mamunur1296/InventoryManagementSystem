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
            var productSizeEntity = _mapper.Map<User>(request);
            await _unitOfWorkDb.userCommandRepository.AddAsync(productSizeEntity);
            await _unitOfWorkDb.SaveAsync();
            var newResponse = _mapper.Map<UserModels>(productSizeEntity);
            return newResponse;
        }
    }
}
