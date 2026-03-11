namespace PJ_API.Domain.Entities
{
    public class Reminder
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int ReminderDay { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }

        public Company Company { get; set; } = null!;
    }
}
