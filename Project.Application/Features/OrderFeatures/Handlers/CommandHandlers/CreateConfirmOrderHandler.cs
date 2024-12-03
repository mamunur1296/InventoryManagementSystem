using MediatR;
using Project.Application.ApiResponse;
using Project.Domail.Abstractions;
using System.Net;

namespace Project.Application.Features.OrderFeatures.Handlers.CommandHandlers
{
    public class CreateConfirmOrderComment : IRequest<ApiResponse<string>>
    {
        public string UserID { get; set; }
        public Dictionary<string, int> ProductIdAndQuentity { get; set; }
    }
    public class CreateConfirmOrderHandler : IRequestHandler<CreateConfirmOrderComment, ApiResponse<string>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;


        public CreateConfirmOrderHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;

        }


        public async Task<ApiResponse<string>> Handle(CreateConfirmOrderComment request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<string>();
            var userId = Guid.Parse(request.UserID);

            var (result,tnumber) = await _unitOfWorkDb.orderCommandRepository.ConfirmOrder(userId, request.ProductIdAndQuentity);
            response.Success = result;
            response.Data = tnumber;
            response.Status = HttpStatusCode.OK; // 200 OK
            return response;
        }

    }
}
