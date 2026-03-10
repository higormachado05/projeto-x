using PJ_API.Domain.Repositories;
using PJ_API.Application.Queries;
using PJ_API.Domain.Entities;

namespace PJ_API.Application.Handlers
{
    public class GetAllPersonsQueryHandler
    {
        private readonly IPersonRepository _repository;
        public GetAllPersonsQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public GetAllPersonsQueryResult Handle(GetAllPersonsQuery query)
        {
            var persons = _repository.GetAll();
            return new GetAllPersonsQueryResult { Persons = persons };
        }
    }
}
