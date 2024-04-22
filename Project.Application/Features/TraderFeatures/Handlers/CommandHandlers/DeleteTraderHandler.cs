using MediatR;
using Project.Application.Features.TraderFeatures.Commands;
using Project.Domail.Abstractions;


namespace Project.Application.Features.TraderFeatures.Handlers.CommandHandlers
{
    public class DeleteTraderHandler : IRequestHandler<DeleteTraderCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteTraderHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }

        public async Task<string> Handle(DeleteTraderCommand request, CancellationToken cancellationToken)
        {
            var date = await _unitOfWorkDb.traderQueryRepository.GetByIdAsync(request.Id);
            if (date == null)
            {
                return "Data not found";
            }
            await _unitOfWorkDb.traderCommandRepository.DeleteAsync(date);
            await _unitOfWorkDb.SaveAsync();
            return "Completed";
        }
    }
}
