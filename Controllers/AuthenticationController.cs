using MediatR;
using Microsoft.AspNetCore.Mvc;
using PJ_API.Application.Commands.Authentication.Login;

namespace PJ_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            if (response is null)
                return Unauthorized(new { message = "E-mail ou senha inválidos." });

            return Ok(response);
        }
    }
}
