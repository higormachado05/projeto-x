using Microsoft.AspNetCore.Mvc;
using PJ_API.Application.Commands.Authentication.Login;
using PJ_API.Application.DTOs;

namespace PJ_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private readonly LoginCommandHandler _loginHandler;

        public AuthenticationController(LoginCommandHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _loginHandler.HandleAsync(command);
            if (result == null)
                return Unauthorized();
            return Ok(result);
        }
    }
}
