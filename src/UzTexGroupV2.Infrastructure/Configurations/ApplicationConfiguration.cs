using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Applications>
{
    public void Configure(EntityTypeBuilder<Applications> builder)
    {
        builder
            .ToTable(nameof(Applications))
            .HasKey(app => app.Id);

        builder
            .Property(app => app.FirstName)
            .IsRequired(true)
            .HasMaxLength(50);

        builder
            .Property(app => app.LastName)
            .HasMaxLength(50);

        builder
            .Property(app => app.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder
            .Property(app => app.ApplicationMessage)
            .IsRequired()
            .HasMaxLength(300);

        builder
            .HasOne(app => app.Address)
            .WithMany()
            .HasForeignKey(app => app.AddressId);

        builder
            .HasOne(app => app.Job)
            .WithMany(job => job.Applications)
            .HasForeignKey(app => new { app.JobId, app.LanguageCode })
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
