using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJ_API.Domain.Entities;

namespace PJ_API.Infrastructure.Configurations
{
    public class WorkSessionConfiguration : IEntityTypeConfiguration<WorkSession>
    {
        public void Configure(EntityTypeBuilder<WorkSession> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.StartTime)
                .IsRequired();

            builder.Property(w => w.EndTime)
                .IsRequired();

            builder.Property(w => w.TotalHours)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(w => w.CreatedAt)
                .IsRequired();

            builder.HasOne(w => w.Company)
                .WithMany(c => c.WorkSessions)
                .HasForeignKey(w => w.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
