using MediatR;

namespace Project.Application.Features.CompanyFeatures.Commands
{
    public class DeleteCompanyCommand : IRequest<string>
    {
        public DeleteCompanyCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
