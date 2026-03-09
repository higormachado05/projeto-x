using Microsoft.AspNetCore.Mvc;
using PJ_API.Application.Handlers;
using PJ_API.Application.Queries;
using PJ_API.Domain.Repositories;
using PJ_API.Infrastructure.Repositories;

namespace PJ_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly GetAllPersonsHandler _handler;

        public PersonsController()
        {
            // Injeção manual para exemplo simples
            _handler = new GetAllPersonsHandler(new PersonRepository());
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _handler.Handle(new GetAllPersonsQuery());
            return Ok(result.Persons);
        }
    }
}
