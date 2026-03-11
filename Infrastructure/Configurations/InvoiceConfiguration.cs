using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJ_API.Domain.Entities;

namespace PJ_API.Infrastructure.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.PeriodStart)
                .IsRequired();

            builder.Property(i => i.PeriodEnd)
                .IsRequired();

            builder.Property(i => i.TotalHours)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.HourRate)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.CreatedAt)
                .IsRequired();

            builder.HasOne(i => i.Company)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
