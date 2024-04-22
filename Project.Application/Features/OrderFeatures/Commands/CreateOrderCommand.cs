using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommand : IRequest<OrderModels>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public bool IsHold { get; set; }
        public bool IsCancel { get; set; }
        public string ReturnProductId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsPlaced { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDispatched { get; set; }
        public bool IsReadyToDispatch { get; set; }
        public bool IsDelivered { get; set; }

    }
}
