using AirBNB.Domain.Hotels;
using AirBNB.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBNB.Infrastructure.EntityConfigurations;

class HotelEntityTypeConfiguration
    : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> hotelConfiguration)
    {
        hotelConfiguration.ToTable("hotel");

        hotelConfiguration.HasKey(u => u.Id);

        hotelConfiguration.Property(u => u.Id)
            .HasColumnType("varchar")
            .ValueGeneratedNever()
            .HasMaxLength(36)
            .IsRequired();

        hotelConfiguration.Property(u => u.Name)
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        hotelConfiguration.Property(u => u.ImageUrl)
            .HasColumnType("varchar")
            .HasMaxLength(2048);

        hotelConfiguration.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);

        hotelConfiguration.Property(u => u.CreatedDateTime)
            .HasColumnType("date");

        hotelConfiguration.Property(u => u.UpdatedDateTime)
            .HasColumnType("date");
    }
}
