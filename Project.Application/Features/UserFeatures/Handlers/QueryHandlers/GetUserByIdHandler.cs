using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.UserFeatures.Queries;
using Project.Domail.Abstractions;


namespace Project.Application.Features.UserFeatures.Handlers.QueryHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.userQueryRepository.GetByIdAsync(request.Id);
            var newData = _mapper.Map<UserDTO>(data);
            return newData;
        }
    }
}
