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
            try
            {
                var product = _mapper.Map<Product>(request);
                await _unitOfWorkDb.productCommandRepository.AddAsync(product);
                await _unitOfWorkDb.SaveAsync();
                var newProduct = _mapper.Map<ProductModels>(product);
                return newProduct;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
