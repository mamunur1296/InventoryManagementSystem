using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.CompanyFeatures.Queries;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ValveFeatures.Handlers.QueryHandlers
{
    public class GetValveByIdHandler : IRequestHandler<GetValveByIdQuery, ValveDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetValveByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ValveDTO> Handle(GetValveByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _unitOfWorkDb.valverQueryRepository.GetByIdAsync(request.Id);
                var newData = _mapper.Map<ValveDTO>(data);
                return newData;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
