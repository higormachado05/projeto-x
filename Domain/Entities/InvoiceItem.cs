namespace PJ_API.Domain.Entities
{
    public class InvoiceItem
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public DateTime WorkDate { get; set; }
        public decimal Hours { get; set; }
        public decimal Amount { get; set; }

        public Invoice Invoice { get; set; } = null!;
    }
}
