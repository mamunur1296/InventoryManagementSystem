using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<ProductModels>
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public Guid ProdSizeId { get; set; }
        public Guid ProdValveId { get; set; }
        public string ProdImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
