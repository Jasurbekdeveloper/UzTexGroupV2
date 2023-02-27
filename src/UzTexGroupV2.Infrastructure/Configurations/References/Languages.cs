using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations.References;

public class Languages : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder
            .ToTable("Languages");

        builder
            .HasData(
                new Language()
                {
                    Id = Guid.NewGuid(),
                    Code = "uz",
                    Name = "Uzbek"
                },
                new Language()
                {
                    Id = Guid.NewGuid(),
                    Code = "en",
                    Name = "English"
                },
                new Language()
                {
                    Id = Guid.NewGuid(),
                    Code = "ru",
                    Name = "Russian"
                });
    }
}