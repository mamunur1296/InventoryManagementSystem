using AutoMapper;
using MediatR;
using Project.Application.Features.ProductSizeFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.ProductSizeFeatures.Handlers.CommandHandlers
{
    public class CreateProductSizeHandler : IRequestHandler<CreateProductSizeCommand, ProductSizeModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateProductSizeHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ProductSizeModels> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productSize = _mapper.Map<ProductSize>(request);
                await _unitOfWorkDb.productSizeCommandRepository.AddAsync(productSize);
                await _unitOfWorkDb.SaveAsync();
                var newProductSize = _mapper.Map<ProductSizeModels>(productSize);
                return newProductSize;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
