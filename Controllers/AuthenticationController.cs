using MediatR;
using Microsoft.AspNetCore.Mvc;
using PJ_API.Application.Commands.Authentication.Login;
using PJ_API.Application.DTOs;

namespace PJ_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;


        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            
            return this.Ok(await this.mediator.Send(command));
        }
    }
}
