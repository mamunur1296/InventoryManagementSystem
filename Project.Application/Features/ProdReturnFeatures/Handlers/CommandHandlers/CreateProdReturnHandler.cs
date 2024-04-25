using AutoMapper;
using MediatR;
using Project.Application.Features.ProdReturnFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.CommandHandlers
{
    public class CreateProdReturnHandler : IRequestHandler<CreateProdReturnCommand, ProdReturnModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateProdReturnHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ProdReturnModels> Handle(CreateProdReturnCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var prodReturn = _mapper.Map<ProdReturn>(request);
                await _unitOfWorkDb.prodReturnCommandRepository.AddAsync(prodReturn);
                await _unitOfWorkDb.SaveAsync();
                var newProdReturn = _mapper.Map<ProdReturnModels>(prodReturn);
                return newProdReturn;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
