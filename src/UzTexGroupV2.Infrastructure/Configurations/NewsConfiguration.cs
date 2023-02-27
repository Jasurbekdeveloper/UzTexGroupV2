using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder
            .ToTable(nameof(News));

        builder
            .HasKey(news => new { news.Id, news.LanguageCode });

        builder
            .Property(news => news.Date)
            .IsRequired();
    }
}