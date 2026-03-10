namespace PJ_API.Application.DTOs
{
    public class GetClientByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
