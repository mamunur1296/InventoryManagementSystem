using Microsoft.AspNetCore.Http;
using Project.Application.Interfaces;
using System.Security.Claims;

namespace Project.Infrastructure.Services
{
    public class LogInUserServices : ILogInUserServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogInUserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value ?? "Null";
        }
    }
}
