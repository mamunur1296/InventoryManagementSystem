using AutoMapper;
using MediatR;
using Project.Application.Features.CompanyFeatures.Commands;
using Project.Application.Features.ProductFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;


namespace Project.Application.Features.ProductFeatures.Handlers.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ProductModels> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productSizeEntity = _mapper.Map<Product>(request);
            await _unitOfWorkDb.productCommandRepository.AddAsync(productSizeEntity);
            await _unitOfWorkDb.SaveAsync();
            var newResponse = _mapper.Map<ProductModels>(productSizeEntity);
            return newResponse;
        }
    }
}
