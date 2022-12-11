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

        bookDateConfiguration.Property(u => u.StartDate)
            .HasColumnType("date");

        bookDateConfiguration.Property(u => u.EndDate)
            .HasColumnType("date");

        bookDateConfiguration.HasOne<Room>().WithMany().HasForeignKey(x => x.RoomId);
    }
}
