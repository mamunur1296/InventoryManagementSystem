using AutoMapper;
using MediatR;
using Project.Application.Features.UserFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;


namespace Project.Application.Features.UserFeatures.Handlers.CommandHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<UserModels> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.userQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.Name = request.Name;
            }
            await _unitOfWorkDb.userCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<UserModels>(data);
            return customerRes;
        }
    }
}
