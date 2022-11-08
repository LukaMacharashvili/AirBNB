using AirBNB.Authentication.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Authentication.Service.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<VerificationToken> VerificationTokens { get; set; }
    }
}
