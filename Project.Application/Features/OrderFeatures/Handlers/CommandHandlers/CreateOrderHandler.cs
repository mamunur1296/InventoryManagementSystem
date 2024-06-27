using MediatR;
using Project.Application.ApiResponse;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Project.Application.Features.OrderFeatures.Handlers.CommandHandlers
{
    public class CreateOrderCommand : IRequest<ApiResponse<string>>
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid ReturnProductId { get; set; }
        public string TransactionNumber { get; set; } //
        public string Comments { get; set; }//
        [Required]
        public string ? CreatedBy { get; set; }
    }
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
      

        public CreateOrderHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
           
        }
 

        public async Task<ApiResponse<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();

            try
            {
                var newOrder = new Order
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now.Date,
                    CreatedBy = request.CreatedBy,
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    ReturnProductId = request.ReturnProductId,
                    TransactionNumber = request.TransactionNumber,
                    Comments = request.Comments,
                    IsHold = true,
                    IsCancel = false,
                    IsDelivered = false,
                    IsConfirmed = false,
                    IsPlaced = false,
                    IsDispatched = false,
                    IsReadyToDispatch = false,

                };

                await _unitOfWorkDb.orderCommandRepository.AddAsync(newOrder);
                await _unitOfWorkDb.SaveAsync();

                response.Success = true;
                response.Data = $" Order id = {newOrder.Id} created successfully!";
                response.Status = HttpStatusCode.OK; // Set status code to 200 (OK)
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = "An error occurred while creating the Order";
                response.ErrorMessage = ex.Message;
                response.Status = HttpStatusCode.InternalServerError; // Set status code to 500 (Internal Server Error)
            }

            return response;
        }
    }
}
