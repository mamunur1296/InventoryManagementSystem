using MediatR;
using Project.Application.Features.StockFeatures.Commands;
using Project.Domail.Abstractions;


namespace Project.Application.Features.StockFeatures.Handlers.CommandHandlers
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteStockHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }

        public async Task<string> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var stock = await _unitOfWorkDb.stockQueryRepository.GetByIdAsync(request.Id);
                if (stock == null)
                {
                    return "Data not found";
                }
                await _unitOfWorkDb.stockCommandRepository.DeleteAsync(stock);
                await _unitOfWorkDb.SaveAsync();
                return "Completed";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
