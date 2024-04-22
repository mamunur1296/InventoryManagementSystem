using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.ProductSizeFeatures.Commands
{
    public class UpdateProductSizeCommand : IRequest<ProductSizeModels>
    {
        public Guid Id { get; set; }
        public decimal Size { get; set; }
        public string? Unit { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
