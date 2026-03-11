using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJ_API.Domain.Entities;

namespace PJ_API.Infrastructure.Configurations
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.WorkDate)
                .IsRequired();

            builder.Property(i => i.Hours)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(i => i.Invoice)
                .WithMany(inv => inv.InvoiceItems)
                .HasForeignKey(i => i.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
