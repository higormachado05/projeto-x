namespace PJ_API.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string BillingType { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;

        public ICollection<WorkSession> WorkSessions { get; set; } = new List<WorkSession>();
    }
}
