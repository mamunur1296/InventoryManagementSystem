using AutoMapper;
using MediatR;
using Project.Application.Features.ProductFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ProductFeatures.Handlers.CommandHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<ProductModels> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.productQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.Name = request.Name;
            }
            await _unitOfWorkDb.productCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<ProductModels>(data);
            return customerRes;
        }
    }
}