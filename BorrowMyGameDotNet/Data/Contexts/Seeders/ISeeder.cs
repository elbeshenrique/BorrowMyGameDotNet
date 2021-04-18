using Microsoft.EntityFrameworkCore;

namespace BorrowMyGameDotNet.Data.Contexts.Seeders
{
    public interface ISeeder
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}