using AirBNB.Domain.BookDates;
using AirBNB.Domain.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBNB.Infrastructure.EntityConfigurations;

class BookDateEntityTypeConfiguration
    : IEntityTypeConfiguration<BookDate>
{
    public void Configure(EntityTypeBuilder<BookDate> bookDateConfiguration)
    {
        bookDateConfiguration.ToTable("bookDate");

        bookDateConfiguration.HasKey(u => u.Id);

        bookDateConfiguration.Property(u => u.Id)
            .HasColumnType("varchar")
            .ValueGeneratedNever()
            .HasMaxLength(36)
            .IsRequired();

        bookDateConfiguration.Property(u => u.Date)
            .HasColumnType("date");

        bookDateConfiguration.HasOne<Room>(s => s.Room)
            .WithMany(r => r.BookDates)
            .HasForeignKey(s => s.RoomId);
    }
}
