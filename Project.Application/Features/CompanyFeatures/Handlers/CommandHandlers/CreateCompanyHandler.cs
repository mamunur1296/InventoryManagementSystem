using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Project.Application.Features.CompanyFeatures.Handlers.CommandHandlers
{
    public class CreateCompanyCommand : IRequest<ApiResponse<string>>
    {
      
        public string Name { get; set; }
        public string Contactperson { get; set; }
        public string ContactPerNum { get; set; }
        public string ContactNumber { get; set; }
        public string BIN { get; set; }

    }
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public CreateCompanyHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }
        public async Task<ApiResponse<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();
            try
            {
                var newCompany = new Company
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    CreatedBy = "Login User ",
                    Name = request.Name,
                    Contactperson = request.Contactperson,
                    ContactPerNum = request.ContactPerNum,
                    ContactNumber = request.ContactNumber,
                    IsActive = true,
                    BIN = request.BIN,
                };

                // Validate the Company model
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(newCompany, new ValidationContext(newCompany), validationResults, true);

                // If the model is not valid, format error messages
                if (!isValid)
                {
                    var errorMessage = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                    response.Success = false;
                    response.Data = errorMessage;
                    response.StatusCode = HttpStatusCode.BadRequest; // Set status code to 400 (Bad Request)
                    return response;
                }

                await _unitOfWorkDb.companyCommandRepository.AddAsync(newCompany);
                await _unitOfWorkDb.SaveAsync();
                response.Success = true;
                response.Data = "Company Created Successfully!";
                response.StatusCode = HttpStatusCode.OK; // Set status code to 200 (OK)
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = "Server Error";
                response.ErrorMessage = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError; // Set status code to 500 (Internal Server Error)
            }

            return response;
        }




    }
}
