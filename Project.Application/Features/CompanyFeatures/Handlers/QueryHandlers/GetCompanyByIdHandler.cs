using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.CompanyFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.CompanyFeatures.Handlers.QueryHandlers
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetCompanyByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<CompanyDTO> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWorkDb.companyrQueryRepository.GetByIdAsync(request.Id);
            var getcompany = _mapper.Map<CompanyDTO>(company);
            return getcompany;
        }
    }
}
