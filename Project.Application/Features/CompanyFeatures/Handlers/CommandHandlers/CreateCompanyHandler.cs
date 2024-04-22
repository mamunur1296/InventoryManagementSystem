using AutoMapper;
using MediatR;
using Project.Application.Features.CompanyFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.CompanyFeatures.Handlers.CommandHandlers
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<CompanyModels> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var newCompany = new Company
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Contactperson = request.Contactperson,
                ContactNumber = request.ContactNumber,
                BIN = request.BIN,
                IsActive = request.IsActive,
                UpdatedBy = "Admin",
                ContactPerNum = request.ContactPerNum,
                CreatedBy = "User1",
                CreationDate = DateTime.Now,
                DeactiveBy="Admin",  
            };

            await _unitOfWorkDb.companyCommandRepository.AddAsync(newCompany);
            await _unitOfWorkDb.SaveAsync();
            var createdCompany = _mapper.Map<CompanyModels>(newCompany);
            return createdCompany;
        }
    }
}
