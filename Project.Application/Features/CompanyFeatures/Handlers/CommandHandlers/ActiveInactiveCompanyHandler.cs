using MediatR;
using Project.Application.ApiResponse;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.CompanyFeatures.Handlers.CommandHandlers
{
    // Command to toggle active/inactive status of a company
    public class ActiveInactiveCompanyCommand : IRequest<ApiResponse<string>>
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string DeactiveBy { get; set; }
    }

    // Handler to process ActiveInactiveCompanyCommand
    public class ActiveInactiveCompanyHandler : IRequestHandler<ActiveInactiveCompanyCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public ActiveInactiveCompanyHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }

        public async Task<ApiResponse<string>> Handle(ActiveInactiveCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();

            try
            {
                var company = await _unitOfWorkDb.companyrQueryRepository.GetByIdAsync(request.Id);
                if (company == null || company.Id != request.Id)
                {
                    response.Success = false;
                    response.Data = "An error occurred while updating the company";
                    response.ErrorMessage = $"Company with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }

                if (request.IsActive)
                {
                    company.IsActive = true;
                    company.DeactivatedDate = null;
                    company.DeactiveBy = null;

                    response.Data = $"Company with id = {company.Id} activated successfully";
                }
                else
                {
                    company.IsActive = false;
                    company.DeactivatedDate = DateTime.Now;
                    company.DeactiveBy = request.DeactiveBy;

                    response.Data = $"Company with id = {company.Id} deactivated successfully";
                }

                // Perform update operation
                await _unitOfWorkDb.companyCommandRepository.UpdateAsync(company);
                await _unitOfWorkDb.SaveAsync();

                response.Success = true;
                response.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                response.Success = false;
                response.Data = "An error occurred while changing the status of the company";
                response.ErrorMessage = ex.Message;
                response.Status = HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
