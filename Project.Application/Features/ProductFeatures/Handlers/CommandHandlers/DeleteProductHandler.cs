using MediatR;
using Project.Application.Features.ProductFeatures.Commands;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ProductFeatures.Handlers.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteProductHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }


        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var date = await _unitOfWorkDb.productQueryRepository.GetByIdAsync(request.Id);
            if (date == null)
            {
                return "Data not found";
            }
            await _unitOfWorkDb.productCommandRepository.DeleteAsync(date);
            await _unitOfWorkDb.SaveAsync();
            return "Completed";
        }
    }
}
