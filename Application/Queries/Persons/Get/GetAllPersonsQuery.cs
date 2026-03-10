using System.Collections.Generic;
using PJ_API.Domain.Entities;

namespace PJ_API.Application.Queries
{
    public class GetAllPersonsQuery : IQuery<GetAllPersonsQueryResult> { }

    public class GetAllPersonsQueryResult
    {
        public IEnumerable<Person> Persons { get; set; } = new List<Person>();
    }
    public interface IQuery<TResult> { }
}
