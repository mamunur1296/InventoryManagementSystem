using MediatR;
using Project.Application.Features.CompanyFeatures.Commands;
using Project.Domail.Abstractions;

namespace Project.Application.Features.CompanyFeatures.Handlers.CommandHandlers
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteCompanyHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }

        public async Task<string> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var deleteCompany = await _unitOfWorkDb.companyrQueryRepository.GetByIdAsync(request.Id);
            if (deleteCompany == null)
            {
                return "Data not found";
            }
            await _unitOfWorkDb.companyCommandRepository.DeleteAsync(deleteCompany);
            await _unitOfWorkDb.SaveAsync();
            return "Completed";
        }
    }
}
