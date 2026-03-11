namespace PJ_API.Domain.Entities
{
    public class WorkSession
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalHours { get; set; }
        public DateTime CreatedAt { get; set; }

        public Company Company { get; set; } = null!;
    }
}
