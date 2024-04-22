using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.CompanyFeatures.Queries;
using Project.Application.Features.UserFeatures.Queries;
using Project.Domail.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.UserFeatures.Handlers.QueryHandlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllUserHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UserDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _unitOfWorkDb.userQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<UserDTO>(x));
            return data;
        }
    }
}
