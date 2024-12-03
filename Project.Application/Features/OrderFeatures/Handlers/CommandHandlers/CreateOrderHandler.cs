﻿using MediatR;
using Project.Application.ApiResponse;
using Project.Application.Interfaces;
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
        public string TransactionNumber { get; set; } 
        public string Comments { get; set; }
        [Required]
        public string ? CreatedBy { get; set; }
    }
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly ILogInUserServices _loginService;

        public CreateOrderHandler(IUnitOfWorkDb unitOfWorkDb, ILogInUserServices loginService)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _loginService = loginService;
        }


        public async Task<ApiResponse<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();

            try
            {
                // Create a new Order object
                var newOrder = new Order
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now.Date,
                    CreatedBy = await _loginService.GetUserName(),
                    UserId = request.UserId,
                    TransactionNumber = request.TransactionNumber,
                    Comments = request.Comments,
                    IsHold = false,
                    IsCancel = false,
                    IsDelivered = false,
                    IsConfirmed = false,
                    IsPlaced = true,
                    IsDispatched = false,
                    IsReadyToDispatch = false,
                };

                // Retrieve stocks asynchronously
                var stocks = await _unitOfWorkDb.stockQueryRepository.GetAllAsync();
                var productStock = stocks.FirstOrDefault(stock => stock.ProductId == request.ProductId);

                // Check if ProductStock exists and update quantity
                if (productStock != null)
                {
                    if (int.TryParse(request.Comments, out int commentsQuantity))
                    {
                        productStock.Quantity -= commentsQuantity;
                    }
                    else
                    {
                        response.Success = false;
                        response.Data = "Invalid quantity specified in comments.";
                        response.Status = HttpStatusCode.BadRequest; // 400 Bad Request
                        return response;
                    }

                    // Update stock asynchronously
                    await _unitOfWorkDb.stockCommandRepository.UpdateAsync(productStock);
                }
                else
                {
                    response.Success = false;
                    response.Data = "Product not found in stock.";
                    response.Status = HttpStatusCode.NotFound; // 404 Not Found
                    return response;
                }

                // Add the new order asynchronously
                await _unitOfWorkDb.orderCommandRepository.AddAsync(newOrder);
                await _unitOfWorkDb.SaveAsync();

                response.Success = true;
                response.Data = $"Order id = {newOrder.Id} created successfully!";
                response.Status = HttpStatusCode.OK; // 200 OK
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = "An error occurred while creating the Order";
                response.ErrorMessage = ex.Message;
                response.Status = HttpStatusCode.InternalServerError; // 500 Internal Server Error
            }

            return response;
        }

    }
}
