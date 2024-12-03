using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs
{
    public class OrderReportDTOs
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TransactionNumber { get; set; }
        public bool IsHold { get; set; }
        public bool IsCancel { get; set; }
        public bool IsPlaced { get; set; }
        public bool IsConfirmed { get; set; }
        public string Comments { get; set; }
        public bool IsDispatched { get; set; }
        public bool IsReadyToDispatch { get; set; }
        public bool IsDelivered { get; set; }
        public ICollection<OrderDetailDTOs> OrderDetail { get; set; } = new List<OrderDetailDTOs>();

    }
}
