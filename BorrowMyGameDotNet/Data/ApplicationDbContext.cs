using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BorrowMyGameDotNet.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Game> Games { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}