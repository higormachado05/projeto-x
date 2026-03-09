using PJ_API.Domain.Repositories;
using PJ_API.Application.Queries;
using PJ_API.Domain.Entities;

namespace PJ_API.Application.Handlers
{
    public class GetAllPersonsHandler
    {
        private readonly IPersonRepository _repository;
        public GetAllPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public GetAllPersonsResult Handle(GetAllPersonsQuery query)
        {
            var persons = _repository.GetAll();
            return new GetAllPersonsResult { Persons = persons };
        }
    }
}
