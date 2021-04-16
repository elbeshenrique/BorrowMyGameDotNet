using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BorrowMyGameDotNet.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game(1, "Half-Life 3", false),
                new Game(2, "Half-Life 2", true),
                new Game(3, "Age of Empires 2", false),
                new Game(4, "SimCity 4000", true),
                new Game(5, "The Elder Scrolls V: Skyrim", false),
                new Game(6, "Fallout 3", false),
                new Game(7, "God Of War", true),
                new Game(8, "Warcraft 3", false)
            );
        }
    }
}