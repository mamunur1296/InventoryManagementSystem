using AutoMapper;
using MediatR;
using Project.Application.Features.CompanyFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;

namespace Project.Application.Features.CompanyFeatures.Handlers.CommandHandlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, CompanyModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateCompanyHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
       
        public async Task<CompanyModels> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWorkDb.companyrQueryRepository.GetByIdAsync(request.Id);
            if (company == null) return default;
            else
            {
                company.BIN = request.BIN;
                company.Name = request.Name;
                company.Contactperson = request.Contactperson;
                company.ContactPerNum = request.ContactPerNum;
                company.ContactNumber = request.ContactNumber;
                company.CreatedBy = request.CreatedBy;
                company.UpdatedBy = request.UpdatedBy;
                company.DeactivatedDate = request.DeactivatedDate;
                company.DeactiveBy = request.DeactiveBy;
                company.IsActive = request.IsActive;

            }
            await _unitOfWorkDb.companyCommandRepository.UpdateAsync(company);
            await _unitOfWorkDb.SaveAsync();
            var companyRequest = _mapper.Map<CompanyModels>(company);
            return companyRequest;
        }
    }
}
//          