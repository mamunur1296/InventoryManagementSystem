using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.DeliveryAddressFeatures.Commands
{
    public class UpdateDeliveryAddressCommand : IRequest<DeliveryAddressModels>
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public string ? DeactiveBy { get; set; }
        public bool? IsDefault { get; set; }
    }
}
