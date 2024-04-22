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
            var data = await _unitOfWorkDb.productSizeQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                
                data.Unit=request.Unit;
                data.UpdatedBy=request.UpdatedBy;
                data.CreatedBy=request.CreatedBy;
            }
            await _unitOfWorkDb.productSizeCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<ProductSizeModels>(data);
            return customerRes;
        }
    }
}
