using AirBNB.Domain.BookDates;
using AirBNB.Domain.Hotels;
using AirBNB.Domain.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBNB.Infrastructure.EntityConfigurations;

class RoomEntityTypeConfiguration
    : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> roomConfiguration)
    {
        roomConfiguration.ToTable("room");

        roomConfiguration.HasKey(u => u.Id);

        roomConfiguration.Property(u => u.Id)
            .HasColumnType("varchar")
            .ValueGeneratedNever()
            .HasMaxLength(36)
            .IsRequired();

        roomConfiguration.Property(u => u.Name)
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        roomConfiguration.Property(u => u.ImageUrl)
            .HasColumnType("varchar")
            .HasMaxLength(2048);

        roomConfiguration.Property(u => u.CreatedDateTime)
            .HasColumnType("datetime");

        roomConfiguration.Property(u => u.UpdatedDateTime)
            .HasColumnType("datetime");

        roomConfiguration.HasOne<Hotel>(r => r.Hotel)
            .WithMany(h => h.Rooms)
            .HasForeignKey(x => x.HotelId);

        roomConfiguration.HasMany<BookDate>(r => r.BookDates)
            .WithOne(b => b.Room)
            .HasForeignKey(x => x.RoomId);
    }
}
