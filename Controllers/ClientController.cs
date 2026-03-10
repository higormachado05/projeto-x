using Microsoft.AspNetCore.Mvc;
using PJ_API.Application.Commands;
using PJ_API.Application.DTOs;
using PJ_API.Application.Queries;

namespace PJ_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly PJ_API.Domain.Repositories.IClientRepository _repository;

        public ClientController(PJ_API.Domain.Repositories.IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<GetClientByIdResponse> GetById(Guid id)
        {
            var client = _repository.GetById(id);
            if (client == null)
                return NotFound();
            return Ok(new GetClientByIdResponse { Id = client.Id, Name = client.Name });
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClientCommand command)
        {
            var client = new PJ_API.Domain.Entities.Client { Name = command.Name };
            _repository.Add(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, null);
        }
    }
}
