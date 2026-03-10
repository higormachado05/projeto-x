namespace PJ_API.Application.DTOs
{
    public class GetAllPersonsResult
    {
        public IEnumerable<object> Persons { get; set; } = new List<object>();
    }
}