using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Domain.Enums;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(user => user.LastName)
            .HasMaxLength(50)
            .IsRequired(false);

        builder
            .HasIndex(user => user.Email)
            .IsUnique();

        builder
            .Property(user => user.PasswordHash)
            .IsRequired();

        builder
            .Property(user => user.UserRole)
            .IsRequired();

        builder.HasData(new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "Elchin",
            LastName = "Uralov",
            Email = "elchinuralov07@gmail.com",
            Salt = "a9feaa2d-8692-4d2e-bf64-3d8200ad8c8b",
            UserRole = Role.SuperAdmin,
            PasswordHash = "v7DrXBP/nQ3sHmWUgp6nkmBkJCeKxVK4+iljRqJfgDI="

        });
    }
}
