using MediatR;
using PJ_API.Application.DTOs;

namespace PJ_API.Application.Commands.Authentication.Login
{
    public class LoginCommand : IRequest<LoginResponse?>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
