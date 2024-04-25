using MediatR;
using Project.Application.Features.ValveFeatures.Commands;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ValveFeatures.Handlers.CommandHandlers
{
    public class DeleteValveHandler : IRequestHandler<DeleteValveCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteValveHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }
        public async Task<string> Handle(DeleteValveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var valve= await _unitOfWorkDb.valverQueryRepository.GetByIdAsync(request.Id);
                if (valve == null)
                {
                    return "Data not found";
                }
                await _unitOfWorkDb.valveCommandRepository.DeleteAsync(valve);
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
