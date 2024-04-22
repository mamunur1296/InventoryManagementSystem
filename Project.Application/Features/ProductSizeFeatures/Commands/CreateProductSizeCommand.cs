using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.ProductSizeFeatures.Commands
{
    public class CreateProductSizeCommand : IRequest<ProductSizeModels>
    {
        public decimal Size { get; set; }
        public string? Unit { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
