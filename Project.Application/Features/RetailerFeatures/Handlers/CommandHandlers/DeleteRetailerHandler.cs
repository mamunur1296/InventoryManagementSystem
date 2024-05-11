﻿using MediatR;
using Project.Application.ApiResponse;
using Project.Application.Exceptions;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.RetailerFeatures.Handlers.CommandHandlers
{
    public class DeleteRetailerCommand : IRequest<ApiResponse<string>>
    {
        public DeleteRetailerCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class DeleteRetailerHandler : IRequestHandler<DeleteRetailerCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteRetailerHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }
        public async Task<ApiResponse<string>> Handle(DeleteRetailerCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();
            var retailer = await _unitOfWorkDb.retailerQueryRepository.GetByIdAsync(request.Id);

            if (retailer == null)
            {
                throw new NotFoundException($"retailer with id = {request.Id} not found");
            }
            else
            {
                try
                {
                    await _unitOfWorkDb.retailerCommandRepository.DeleteAsync(retailer);
                    await _unitOfWorkDb.SaveAsync();

                    response.Success = true;
                    response.Data = $"retailer with id = {retailer.Id} deleted successfully";
                    response.StatusCode = HttpStatusCode.OK; // Set status code to 200 (OK)
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Data = "An error occurred while deleting the retailer  ";
                    response.ErrorMessage = ex.Message;
                    response.StatusCode = HttpStatusCode.InternalServerError;  // Set status code to 500 (Internal Server Error)
                }

            }
            return response;
        }
    }
}
