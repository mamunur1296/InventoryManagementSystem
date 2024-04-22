using MediatR;
using Project.Application.Features.ProductSizeFeatures.Commands;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProductSizeFeatures.Handlers.CommandHandlers
{
    internal class DeleteProductSizeHandler : IRequestHandler<DeleteProductSizeCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteProductSizeHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }

        public async Task<string> Handle(DeleteProductSizeCommand request, CancellationToken cancellationToken)
        {
            var date = await _unitOfWorkDb.productSizeQueryRepository.GetByIdAsync(request.Id);
            if (date == null)
            {
                return "Data not found";
            }
            await _unitOfWorkDb.productSizeCommandRepository.DeleteAsync(date);
            await _unitOfWorkDb.SaveAsync();
            return "Completed";
        }
    }
}
