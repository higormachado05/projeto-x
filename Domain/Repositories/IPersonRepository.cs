using System.Collections.Generic;
using PJ_API.Domain.Entities;

namespace PJ_API.Domain.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
    }
}
