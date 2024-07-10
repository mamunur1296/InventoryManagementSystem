using MediatR;
using Project.Application.ApiResponse;
using Project.Application.Exceptions;
using Project.Domail.Abstractions;
using Project.Domail.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace Project.Application.Features.StockFeatures.Handlers.CommandHandlers
{
    public class UpdateStockCommand : IRequest<ApiResponse<string>>
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid TraderId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public string UpdatedBy { get; set; }

    }
    public class UpdateStockHandler : IRequestHandler<UpdateStockCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public UpdateStockHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }



        public async Task<ApiResponse<string>> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            // Initialize response object
            var response = new ApiResponse<string>();

            // Retrieve the stock by id
            var stock = await _unitOfWorkDb.stockQueryRepository.GetByIdAsync(request.Id);

            // Check if the stock exists
          
            if (stock == null || stock.Id != request.Id)
            {

                response.Success = false;
                response.Data = "An error occurred while updating the stock  ";
                response.ErrorMessage = $"stock  with id = {request.Id} not found";
                response.Status = HttpStatusCode.NotFound;
                return response;
            }
            try
            {


                // Update stock properties
                stock.UpdatedBy = request.UpdatedBy;
                stock.ProductId = request.ProductId;
                stock.TraderId = request.TraderId;
                stock.Quantity = request.Quantity;



                // Perform the update operation
                await _unitOfWorkDb.stockCommandRepository.UpdateAsync(stock);
                await _unitOfWorkDb.SaveAsync();

                // Set success response
                response.Success = true;
                response.Data = $"stock with id = {stock.Id} updated successfully";
                response.Status = HttpStatusCode.OK; // Set status code to 200 (OK)
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                response.Success = false;
                response.Data = "An error occurred while updating the stock ";
                response.ErrorMessage = ex.Message;
                response.Status = HttpStatusCode.InternalServerError; // Set status code to 500 (Internal Server Error)
            }

            // Return the response
            return response;
        }
    }
}
