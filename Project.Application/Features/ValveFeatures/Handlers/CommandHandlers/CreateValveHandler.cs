using AutoMapper;
using MediatR;
using Project.Application.Features.ValveFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;


namespace Project.Application.Features.ValveFeatures.Handlers.CommandHandlers
{
    public class CreateValveHandler : IRequestHandler<CreateValveCommand, ValveModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateValveHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<ValveModels> Handle(CreateValveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productSizeEntity = _mapper.Map<Valve>(request);
                await _unitOfWorkDb.valveCommandRepository.AddAsync(productSizeEntity);
                await _unitOfWorkDb.SaveAsync();
                var newResponse = _mapper.Map<ValveModels>(productSizeEntity);
                return newResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
