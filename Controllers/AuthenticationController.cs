using Microsoft.AspNetCore.Mvc;
using PJ_API.Application.Commands.Authentication.Login;

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
            try
            {
                var message = await _loginHandler.HandleAsync(command);
                if (message == null)
                    return Unauthorized(new { message = "Email ou senha inválidos." });

                return Ok(new { message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
