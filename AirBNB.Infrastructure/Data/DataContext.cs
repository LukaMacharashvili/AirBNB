using AirBNB.Domain.BookDates;
using AirBNB.Domain.Hotels;
using AirBNB.Domain.Rooms;
using AirBNB.Domain.Users;
using AirBNB.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BookDate> BookDate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HotelEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookDateEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
                optionsBuilder.UseMySql(serverVersion);
            }
        }
    }
}