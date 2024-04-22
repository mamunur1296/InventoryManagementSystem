using AutoMapper;
using MediatR;
using Project.Application.Features.ValveFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ValveFeatures.Handlers.CommandHandlers
{
    public class UpdateValveHandler : IRequestHandler<UpdateValveCommand, ValveModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateValveHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

 
        public async Task<ValveModels> Handle(UpdateValveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _unitOfWorkDb.valverQueryRepository.GetByIdAsync(request.Id);
                if (data == null) return default;
                else
                {
                    data.Name = request.Name;
                }
                await _unitOfWorkDb.valveCommandRepository.UpdateAsync(data);
                await _unitOfWorkDb.SaveAsync();
                var customerRes = _mapper.Map<ValveModels>(data);
                return customerRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
