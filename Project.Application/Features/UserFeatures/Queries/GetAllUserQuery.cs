using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.UserFeatures.Queries
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDTO>>
    {
    }
}
