using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJ_API.Domain.Entities;

namespace PJ_API.Infrastructure.Configurations
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.ReminderDay)
                .IsRequired();

            builder.Property(r => r.Value)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(r => r.Active)
                .IsRequired();

            builder.HasOne(r => r.Company)
                .WithMany(c => c.Reminders)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
