namespace PJ_API.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal TotalHours { get; set; }
        public decimal HourRate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public Company Company { get; set; } = null!;

        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
