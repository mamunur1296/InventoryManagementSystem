using MediatR;
using Project.Application.Interfaces;

namespace Project.Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string FirstName { get; set; }
        public string LaststName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserImg {  get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmationPassword { get; set; }
        public List<string> Roles { get; set; }
        public string? TIN { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(request.UserName, request.Password, request.Email,request.FirstName,request.LaststName, request.Roles);
            return result.isSucceed ? result.userId : "User not created .....";
        }
    }
}


