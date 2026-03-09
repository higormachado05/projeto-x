using System.Collections.Generic;
using PJ_API.Domain.Entities;

namespace PJ_API.Application.Queries
{
    public class GetAllPersonsQuery { }

    public class GetAllPersonsResult
    {
        public IEnumerable<Person> Persons { get; set; } = new List<Person>();
    }
}
