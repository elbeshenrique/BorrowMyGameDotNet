using BorrowMyGameDotNet.Data.Contexts.Seeders;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BorrowMyGameDotNet.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            GameSeeder.Create().OnModelCreating(modelBuilder);
            FriendSeeder.Create().OnModelCreating(modelBuilder);
        }
    }
}