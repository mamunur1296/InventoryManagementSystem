using MediatR;
using Project.Application.ApiResponse;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using Project.Application.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.Extensions.Logging;
using Project.Application.Interfaces;

namespace Project.Application.Features.OrderFeatures.Handlers.CommandHandlers
{
    public class CreateOrderCommand : IRequest<ApiResponse<string>>
    {
        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "ReturnProductId is required.")]
        public Guid ReturnProductId { get; set; }

        public string TransactionNumber { get; set; }

        [Required(ErrorMessage = "Comments are required.")]
        public string Comments { get; set; }

        public string CreatedBy { get; set; }
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IIdentityService _identityService;
        private readonly IUtilities _utilities;

        public CreateOrderHandler(IUnitOfWorkDb unitOfWorkDb, IIdentityService identityService, IUtilities utilities)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _identityService = identityService;
            _utilities = utilities;
        }

        public async Task<ApiResponse<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();

            try
            {
                if(!await _unitOfWorkDb.productQueryRepository.IsInExistsAsync(request.ProductId) ) 
                {
                    response.Success = false;
                    response.Status = HttpStatusCode.BadRequest;
                    response.ErrorMessage = "Invalid Product Id.";
                    return response;
                }
                if (!await _unitOfWorkDb.prodReturnQueryRepository.IsInExistsAsync(request.ReturnProductId))
                {
                    response.Success = false;
                    response.Status = HttpStatusCode.BadRequest;
                    response.ErrorMessage = "Invalid Return Product Id.";
                    return response;
                }
                if (!await _identityService.IsUserExistsAsync(request.UserId.ToString()))
                {
                    response.Success = false;
                    response.Status = HttpStatusCode.BadRequest;
                    response.ErrorMessage = "Invalid User Id.";
                    return response;
                }

                var newOrder = new Order
                {
                    Id = _utilities.GenerateNewGuid(),
                    CreationDate = DateTime.Now,
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
                response.Data = $"Order id = {newOrder.Id} created successfully!";
                response.Status = HttpStatusCode.Created; // Set status code to 201 (Created)
            }
            catch (Exception ex)
            {
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                response.Success = false;
                response.Data = "An error occurred while creating the Order";
                response.ErrorMessage = $"Exception Message: {ex.Message}, Inner Exception: {innerExceptionMessage}, StackTrace: {ex.StackTrace}";
                response.Status = HttpStatusCode.InternalServerError; // Set status code to 500 (Internal Server Error)
            }

            return response;
        }
    }
}
