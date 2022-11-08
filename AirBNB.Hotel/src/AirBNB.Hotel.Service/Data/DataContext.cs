using AirBNB.Hotels.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Hotels.Service.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BookDate> BookDates { get; set; }
    }
}
