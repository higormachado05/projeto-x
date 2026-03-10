using PJ_API.Domain.Repositories;
using PJ_API.Application.DTOs;
using PJ_API.Domain.Entities;

namespace PJ_API.Application.Commands
{
    public class GetAllPersonsCommandHandler
    {
        private readonly IPersonRepository _repository;
        public GetAllPersonsCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public GetAllPersonsResult Handle(object query)
        {
            var persons = _repository.GetAll();
            return new GetAllPersonsResult { Persons = persons };
        }
    }
}
