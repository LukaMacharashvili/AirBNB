using AirBNB.Admin.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Admin.Service.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
