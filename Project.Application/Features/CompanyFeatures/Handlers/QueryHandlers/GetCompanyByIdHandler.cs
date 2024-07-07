using AutoMapper;
using MediatR;
using Project.Application.ApiResponse;
using Project.Application.DTOs;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.CompanyFeatures.Handlers.QueryHandlers
{
    public class GetCompanyByIdQuery : IRequest<ApiResponse<CompanyDTO>>
    {
        public GetCompanyByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }

    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, ApiResponse<CompanyDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetCompanyByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<ApiResponse<CompanyDTO>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<CompanyDTO>();

            try
            {
                var company = await _unitOfWorkDb.companyrQueryRepository.GetByIdAsync(request.Id);

                if (company == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"Company with id = {request.Id} not found";
                    response.Status = HttpStatusCode.NotFound;
                    return response;
                }

                var companyDto = _mapper.Map<CompanyDTO>(company);
                response.Data = companyDto;
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
