using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.CompanyFeatures.Handlers.QueryHandlers
{
    public class GetAllCompanyQuery : IRequest<ApiResponse<IEnumerable<CompanyDTO>>>
    {
    }

    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyQuery, ApiResponse<IEnumerable<CompanyDTO>>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetAllCompanyHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CompanyDTO>>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<IEnumerable<CompanyDTO>>();

            try
            {
                
                // Get all companies
                var companyList = await _unitOfWorkDb.companyrQueryRepository.GetAllAsync();

                // Map companies to DTOs
                var companyDtos = companyList.Select(item => _mapper.Map<CompanyDTO>(item)).ToList();

                response.Data = companyDtos;
                response.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Status = HttpStatusCode.InternalServerError;
                // Log the exception or handle it accordingly
            }

            return response;
        }
    }
}
