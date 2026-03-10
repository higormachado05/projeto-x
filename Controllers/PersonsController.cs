using Microsoft.AspNetCore.Mvc;
using PJ_API.Application.Commands;
using PJ_API.Application.Queries;
using PJ_API.Domain.Repositories;
using PJ_API.Infrastructure.Repositories;

namespace PJ_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly GetAllPersonsCommandHandler _handler;

        public PersonsController()
        {
            // Injeção manual para exemplo simples
            _handler = new GetAllPersonsCommandHandler(new PersonRepository());
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _handler.Handle(new GetAllPersonsQuery());
            return Ok(result.Persons);
        }
    }
}
