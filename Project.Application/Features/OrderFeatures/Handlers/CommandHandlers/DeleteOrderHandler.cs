using MediatR;
using Project.Application.ApiResponse;
using Project.Application.Exceptions;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.Net;

namespace Project.Application.Features.OrderFeatures.Handlers.CommandHandlers
{
    public class DeleteOrderCommand : IRequest<ApiResponse<string>>
    {
        public DeleteOrderCommand(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; private set; }
    }
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteOrderHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }
   

        public async Task<ApiResponse<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();
            var order = await _unitOfWorkDb.orderQueryRepository.GetByIdAsync(request.id);

            if (order == null)
            {
                response.Success = false;
                response.Data = "An error occurred while deleting the order";
                response.ErrorMessage = $"order with id = {request.id} not found";
                response.Status = HttpStatusCode.NotFound;
                return response;
            }
            else
            {
                try
                {
                    await _unitOfWorkDb.orderCommandRepository.DeleteAsync(order);
                    await _unitOfWorkDb.SaveAsync();

                    response.Success = true;
                    response.Data = $"order with id = {order.Id} deleted successfully";
                    response.Status = HttpStatusCode.OK; // Set status code to 200 (OK)
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Data = "An error occurred while deleting the order ";
                    response.ErrorMessage = ex.Message;
                    response.Status = HttpStatusCode.InternalServerError;  // Set status code to 500 (Internal Server Error)
                }

            }
            return response;
        }
    }
}
