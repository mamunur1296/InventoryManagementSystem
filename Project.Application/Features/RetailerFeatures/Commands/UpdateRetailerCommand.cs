using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.RetailerFeatures.Commands
{
    public class UpdateRetailerCommand : IRequest<RetailerModel>
    {
        public Guid Id { get; set; }
        public string ? Name { get; set; }
        public string? Contactperson { get; set; }
        public string? ContactPerNum { get; set; }
        public string? ContactNumber { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public string? DeactiveBy { get; set; }
        public string? BIN { get; set; }
    }
}
