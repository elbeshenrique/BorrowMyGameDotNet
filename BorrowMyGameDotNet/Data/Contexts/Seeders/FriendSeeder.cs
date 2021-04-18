using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BorrowMyGameDotNet.Data.Contexts.Seeders
{
    public class FriendSeeder : ISeeder
    {
        public static FriendSeeder Create()
        {
            return new FriendSeeder();
        }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(
                new Friend(1, "Ellen Ripley"),
                new Friend(2, "Bruce Wayne"),
                new Friend(3, "Tony Stark"),
                new Friend(4, "Lara Croft")
            );
        }
    }
}