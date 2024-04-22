using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
