using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.CompanyFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.CompanyFeatures.Handlers.QueryHandlers
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyQuery, IEnumerable<CompanyDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllCompanyHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDTO>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var companyList = await _unitOfWorkDb.companyrQueryRepository.GetAllAsync();
                var productList = await _unitOfWorkDb.productQueryRepository.GetAllAsync();
                var tradersList = await _unitOfWorkDb.traderQueryRepository.GetAllAsync();
                foreach (var company in companyList)
                {
                    company.Products = productList.Where(x => x.CompanyId == company.Id).ToList();
                    company.Traders = tradersList.Where(x => x.CompanyId == company.Id).ToList();
                }
                var companyDtos = companyList.Select(item => _mapper.Map<CompanyDTO>(item));
                return companyDtos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
