using AirBNB.Domain.Hotels;
using AirBNB.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBNB.Infrastructure.EntityConfigurations;

class UserEntityTypeConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> userConfiguration)
    {
        userConfiguration.ToTable("user");

        userConfiguration.HasKey(u => u.Id);

        userConfiguration.Property(u => u.Id)
            .HasColumnType("varchar")
            .HasMaxLength(36)
            .IsRequired();

        userConfiguration.Property(u => u.FirstName)
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        userConfiguration.Property(u => u.LastName)
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        userConfiguration.Property(u => u.Email)
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        userConfiguration.Property(u => u.Password)
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        userConfiguration.Property(u => u.CreatedDateTime)
            .HasColumnType("datetime");

        userConfiguration.Property(u => u.UpdatedDateTime)
            .HasColumnType("datetime");

        userConfiguration.HasMany<Hotel>(u => u.Hotels)
            .WithOne(h => h.User)
            .HasForeignKey(h => h.UserId);
    }
}
