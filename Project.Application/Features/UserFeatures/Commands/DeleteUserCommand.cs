using MediatR;


namespace Project.Application.Features.UserFeatures.Commands
{
    public class DeleteUserCommand : IRequest<string>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
