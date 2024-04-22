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
            var productSizeEntity = _mapper.Map<ProdReturn>(request);
            await _unitOfWorkDb.prodReturnCommandRepository.AddAsync(productSizeEntity);
            await _unitOfWorkDb.SaveAsync();
            var newResponse = _mapper.Map<ProdReturnModels>(productSizeEntity);
            return newResponse;
        }
    }
}
