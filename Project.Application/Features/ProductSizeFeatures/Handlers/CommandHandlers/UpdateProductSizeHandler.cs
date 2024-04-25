using AutoMapper;
using MediatR;
using Project.Application.Features.ProductSizeFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProductSizeFeatures.Handlers.CommandHandlers
{
    public class UpdateProductSizeHandler : IRequestHandler<UpdateProductSizeCommand, ProductSizeModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateProductSizeHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<ProductSizeModels> Handle(UpdateProductSizeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productSize = await _unitOfWorkDb.productSizeQueryRepository.GetByIdAsync(request.Id);
                if (productSize == null) return default;
                else
                {

                    productSize.Unit = request.Unit;
                    productSize.UpdatedBy = request.UpdatedBy;
                    productSize.CreatedBy = request.CreatedBy;
                }
                await _unitOfWorkDb.productSizeCommandRepository.UpdateAsync(productSize);
                await _unitOfWorkDb.SaveAsync();
                var productSizeRes = _mapper.Map<ProductSizeModels>(productSize);
                return productSizeRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
