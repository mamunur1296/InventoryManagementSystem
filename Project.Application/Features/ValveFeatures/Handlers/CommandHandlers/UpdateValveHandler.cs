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
                var valve = await _unitOfWorkDb.valverQueryRepository.GetByIdAsync(request.Id);
                if (valve == null) return default;
                else
                {
                    valve.Name = request.Name;
                }
                await _unitOfWorkDb.valveCommandRepository.UpdateAsync(valve);
                await _unitOfWorkDb.SaveAsync();
                var customerRes = _mapper.Map<ValveModels>(valve);
                return customerRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
