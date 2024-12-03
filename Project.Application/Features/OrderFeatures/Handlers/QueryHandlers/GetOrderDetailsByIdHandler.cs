using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Domail.Abstractions;

namespace Project.Application.Features.OrderFeatures.Handlers.QueryHandlers
{
    public class GetOrderDetailsByIdQuery : IRequest<OrderReportDTOs>
    {
        public GetOrderDetailsByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
    public class GetOrderDetailsByIdHandler : IRequestHandler<GetOrderDetailsByIdQuery, OrderReportDTOs>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetOrderDetailsByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<OrderReportDTOs> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetch the order by ID, including related details
                var order = await _unitOfWorkDb.orderQueryRepository.GetOrderReportById(request.Id);

                if (order == null)
                {
                    throw new Exception("Order not found.");
                }

                // Map the order entity to the OrderReportDTOs
                var reportOrders = new OrderReportDTOs
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    TransactionNumber = order.TransactionNumber,
                    IsHold = order.IsHold,
                    IsCancel = order.IsCancel,
                    IsPlaced = order.IsPlaced,
                    IsConfirmed = order.IsConfirmed,
                    Comments = order.Comments,
                    IsDispatched = order.IsDispatched,
                    IsReadyToDispatch = order.IsReadyToDispatch,
                    IsDelivered = order.IsDelivered,
                    OrderDetail = order.PurchaseDetails.Select(od => new OrderDetailDTOs
                    {
                        OrderID = od?.OrderID.ToString(),
                        ProductID = od?.ProductID.ToString(),
                        Product = od?.Product,
                        UnitPrice = od.UnitPrice,
                        Quantity = od.Quantity,
                        Discount = (decimal)od.Discount
                    }).ToList()
                };

                return reportOrders;
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                throw new Exception("Error while generating the order report", ex);
            }

        }
    }
}
