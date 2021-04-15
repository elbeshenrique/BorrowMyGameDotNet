using BorrowMyGameDotNet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BorrowMyGameDotNet.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<GameModel> Games { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}