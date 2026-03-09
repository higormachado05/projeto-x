using System.Collections.Generic;
using PJ_API.Domain.Entities;
using PJ_API.Domain.Repositories;

namespace PJ_API.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            return new List<Person>
            {
                new Person { Id = 1, Name = "Alice" },
                new Person { Id = 2, Name = "Bob" }
            };
        }
    }
}
