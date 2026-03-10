using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJ_API.Domain.Entities;

namespace PJ_API.Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Document)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.BillingType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Rate)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(u => u.Companies)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
