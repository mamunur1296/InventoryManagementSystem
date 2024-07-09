using MediatR;
using Project.Application.ApiResponse;
using Project.Application.Exceptions;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project.Application.Features.DeliveryAddressFeatures.Handlers.CommandHandlers
{
    public class UpdateDeliveryAddressCommand : IRequest<ApiResponse<string>>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 50 characters.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Phone must be 11 digits.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Mobile is required.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Mobile must be 11 digits.")]
        public string? Mobile { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public string? DeactiveBy { get; set; }
        public bool? IsDefault { get; set; }
        public string? UpdatedBy { get; set; }

    }
    public class UpdateDeliveryAddressHandler : IRequestHandler<UpdateDeliveryAddressCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        public UpdateDeliveryAddressHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
            
        }

        public async Task<ApiResponse<string>> Handle(UpdateDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            // Initialize response object
            var response = new ApiResponse<string>();

            // Retrieve the delivery address by id
            var deliveryAddress = await _unitOfWorkDb.deliveryAddressQueryRepository.GetByIdAsync(request.Id);

            // Check if the delivery address exists
            
            if (deliveryAddress == null || deliveryAddress.Id != request.Id)
            {

                response.Success = false;
                response.Data = "An error occurred while updating the Delivery Address";
                response.ErrorMessage = $"Delivery Address with id = {request.Id} not found";
                response.Status = HttpStatusCode.NotFound;
                return response;
            }


            try
            {
                

                // Update delivery address properties
                deliveryAddress.UserId = request.UserId;
                deliveryAddress.Address = request.Address;
                deliveryAddress.Phone = request.Phone;
                deliveryAddress.Mobile = request.Mobile;
                deliveryAddress.UpdatedBy = request.UpdatedBy;
                deliveryAddress.IsActive = request.IsActive;
                deliveryAddress.IsDefault= request.IsDefault;
                deliveryAddress.DeactiveBy = request.DeactiveBy;
                if ((bool)!deliveryAddress.IsActive) deliveryAddress.DeactivatedDate = DateTime.Now;
                else deliveryAddress.DeactivatedDate = null;



                // Perform the update operation
                await _unitOfWorkDb.deliveryAddressCommandRepository.UpdateAsync(deliveryAddress);
                await _unitOfWorkDb.SaveAsync();

                // Set success response
                response.Success = true;
                response.Data = $"Delivery Address with id = {deliveryAddress.Id} updated successfully";
                response.Status = HttpStatusCode.OK; // Set status code to 200 (OK)
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                response.Success = false;
                response.Data = "An error occurred while updating the delivery address";
                response.ErrorMessage = ex.Message;
                response.Status = HttpStatusCode.InternalServerError; // Set status code to 500 (Internal Server Error)
            }

            // Return the response
            return response;
        }

    }
}
