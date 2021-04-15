using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Entities
{
    [Table("Games")]
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }

        public Game()
        {
        }

        public Game(int id, string title, bool isBorrowed)
        {
            Id = id;
            Title = title;
            IsBorrowed = isBorrowed;
        }

    }
}