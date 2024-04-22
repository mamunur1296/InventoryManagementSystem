using MediatR;

namespace Project.Application.Features.ProdReturnFeatures.Commands
{
    public class DeleteProdReturnCommand : IRequest<string> 
    {
        public DeleteProdReturnCommand(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; private set; }    
    }
}
